public class MainHandler
{
    private Dispatcher dispatcher;
    public MainHandler() => dispatcher = new Dispatcher();
    private bool IsAutheticated() => true;
    private void SetLog(string request) => Console.WriteLine($"Request received: {request}");

    public void ReceiveRequest(string request)
    {
        SetLog(request);
        if (IsAutheticated())
            dispatcher.Dispatch(request);
        else
            throw new Exception("Unauthenticated user error");
    }
}
public class Dispatcher
{
    BookController bookController;
    AuthorController authorController;
    public Dispatcher()
    {
        bookController = new BookController();
        authorController = new AuthorController();
    }
    public void Dispatch(string request)
    {
        if (request.Contains("/book/"))
            bookController.Get();
        else
            authorController.Get();
    }
}
public class BookController
{
    public void Get()
    {
        Console.WriteLine("Design Patterns in .NET");
        Console.WriteLine("C# Programming");
    }
}
public class AuthorController
{
    public void Get()
    {
        Console.WriteLine("Vahid Farahmandian");
        Console.WriteLine("Ali Rahimi");
        Console.WriteLine("Reza Karimi");
    }
}