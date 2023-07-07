public class Request
{
    public string IP { get; set; }
    public string Url { get; set; }
    public string Username { get; set; }
}
public abstract class RequestHandler
{
    RequestHandler _successor;
    public abstract void Handle(Request request);
    public void ContinueWith(RequestHandler handler) { _successor = handler; }
    protected void Next(Request request)
    {
        if (_successor != null)
            _successor.Handle(request);
    }
}
public class AuthenticationHandler : RequestHandler
{
    public override void Handle(Request request)
    {
        if (!string.IsNullOrWhiteSpace(request.Username))// && UserHasAccess(request.Username, request.Url))
            Next(request);
        else
            throw new System.Exception("User not authenticated");
    }
}
public class AuthorizationHandler : RequestHandler
{
    public override void Handle(Request request)
    {
        if (request.IP.StartsWith("10."))
        {
            Next(request);
        }
        else
            throw new System.Exception("Access Denied");
    }
}
public class LoggingHandler : RequestHandler
{
    public override void Handle(Request request)
    {
        //log the request here

        Next(request);
    }
}