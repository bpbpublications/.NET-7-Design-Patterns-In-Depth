public class LoginModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
}
public class UserController
{
    private IView view;
    public IView LoginIndex()
    {
        view = new LoginView();
        view.Display();
        return view;
    }

    public IView DashboardIndex(LoginModel model)
    {
        if (model == null)
            return LoginIndex();
        else
        {
            model.FullName = "Vahid Farahmandian";
            view = new DashboardView(model);
            view.Display();
        }
        return view;
    }

    public IView Login(LoginModel model)
    {
        if (model.UserName == "vahid" && model.Password == "123")
        {
            return DashboardIndex(model);
        }
        else
            return LoginIndex();
    }
    public IView Logout() => LoginIndex();
}
public interface IView
{
    void Display();
}
public class LoginView : IView
{
    readonly LoginModel model;
    readonly UserController controller;

    public LoginView()
    {
        model = new LoginModel();
        controller = new UserController();
    }

    public void Display()
    {
        Console.WriteLine($"Enter username:");
        model.UserName = Console.ReadLine();
        Console.WriteLine($"Enter password:");
        model.Password = Console.ReadLine();
    }

    public IView Login() => controller.Login(model);
}
public class DashboardView : IView
{
    readonly LoginModel model;
    readonly UserController controller;
    public DashboardView(LoginModel model)
    {
        this.model = model;
        controller = new UserController();
    }
    public void Display() => Console.WriteLine($"Username: {model.UserName}, Password: {model.Password}, FullName: {model.FullName}");
    public IView Logout()
    {
        Console.WriteLine("User logged out successfully");
        return controller.Logout();
    }
}