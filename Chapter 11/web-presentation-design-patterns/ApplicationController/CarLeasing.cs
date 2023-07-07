using System.Collections.Specialized;
using System.Web;

public enum State : byte
{
    OnLease = 1,
    InInventory = 2,
    InRepair = 3
}
public class FrontController
{
    public void ReceiveRequest(Uri requestUrl)
    {
        IApplicationController controller = GetApplicationController(requestUrl.AbsoluteUri);

        NameValueCollection requestParams = HttpUtility.ParseQueryString(requestUrl.Query);
        IDomainCommand command = controller.GetCommand(requestUrl.Fragment.TrimStart('#'), requestParams);
        command.run(requestParams);
        string view = controller.GetView(requestUrl.Fragment.TrimStart('#'), requestParams);
        Console.WriteLine($"navigating to view: {view}");
    }

    private IApplicationController GetApplicationController(string requestUrl)
    {
        if (requestUrl.Contains("/leasing/") || requestUrl.Contains("/leasing?"))
            return new CarLeasingApplicationController();
        else
            return null;
    }
}
public interface IApplicationController
{
    IDomainCommand GetCommand(string command, NameValueCollection @params);
    string GetView(string command, NameValueCollection @params);
}
public class CarLeasingApplicationController : IApplicationController
{
    private readonly List<ResponseStore> events = new();
    public CarLeasingApplicationController()
    {
        AddResponse("return", State.OnLease, typeof(ReturnDetailCommand), "return");
        AddResponse("return", State.InInventory, typeof(IllegalActionCommand), "illegalAction");
        AddResponse("damage", State.OnLease, typeof(LeaseDamageCommand), "leaseDamage");
        AddResponse("damage", State.InInventory, typeof(InventoryDamageCommand), "inventoryDamage");
    }
    private Response GetResponse(string command, State state) => events.FirstOrDefault(x => x.Command == command && x.State == state).Response;
    private State GetCarState(NameValueCollection @params) => (State)Convert.ToByte(@params["state"]);
    public IDomainCommand GetCommand(string command, NameValueCollection @params) => GetResponse(command, GetCarState(@params)).GetDomainCommand();
    public string GetView(string command, NameValueCollection @params) => GetResponse(command, GetCarState(@params)).GetView();
    public void AddResponse(string command, State state, Type domainCommand, string view)
    {
        Response response = new(domainCommand, view);
        if (events.All(x => x.GetType() != domainCommand))
            events.Add(new ResponseStore()
            {
                Command = command,
                Response = response,
                State = state
            });
        else
        {
            var @event = events.FirstOrDefault(x => x.Command == command);
            @event.State = state;
            @event.Response = response;
        }
    }
}
public struct ResponseStore
{
    public string Command { get; set; }
    public State State { get; set; }
    public Response Response { get; set; }
}
public class Response
{
    private Type domainCommand;
    private string view;
    public Response(Type domainCommand, string view)
    {
        this.domainCommand = domainCommand;
        this.view = view;
    }
    public IDomainCommand GetDomainCommand() => (IDomainCommand)Activator.CreateInstance(domainCommand);
    public string GetView() => view;
}

public interface IDomainCommand
{
    abstract public void run(NameValueCollection @params);
}
public class ReturnDetailCommand : IDomainCommand
{
    public void run(NameValueCollection @params) => Console.WriteLine("return detail data recorded.");
}
public class IllegalActionCommand : IDomainCommand
{
    public void run(NameValueCollection @params) => Console.WriteLine("Illegal action requested.");
}
public class LeaseDamageCommand : IDomainCommand
{
    public void run(NameValueCollection @params) => Console.WriteLine("Lease damage data recorded.");
}
public class InventoryDamageCommand : IDomainCommand
{
    public void run(NameValueCollection @params) => Console.WriteLine("Inventory damage data recorded.");
}