public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
}
public class BookFinder
{
    static List<Book> books = new()
        {
            new Book()
            {
                   BookId=1,
                   AuthorId=1,
                   Title="Book 1"
            },
            new Book()
            {
                   BookId=2,
                   AuthorId=1,
                   Title="Book 2"
            },
            new Book()
            {
                   BookId=3,
                   AuthorId=2,
                   Title="Book 3"
            }
        };
    public List<Book> GetAuthorBooks(int authorId) => books.Where(book => book.AuthorId == authorId).ToList();
}
public class BookFinderStub : BookFinder
{
    public List<Book> GetAuthorBooks(int authorId)
    {
        return new List<Book>()
            {
                new Book()
                {
                    BookId=1,
                    AuthorId=1,
                    Title="Book 1"
                },
                new Book()
                {
                    BookId=2,
                    AuthorId=1,
                    Title="Book 2"
                }
            };
    }
}
public class Registry
{
    private static Registry _registry = new();
    protected BookFinder bookFinder = new();
    public static BookFinder BookFinder() => _registry.bookFinder;
    public static void Initialize() => _registry = new Registry();
    public static void InitializeStub() => _registry = new RegistryStub();
}
public class RegistryStub : Registry
{
    public RegistryStub() => base.bookFinder = new BookFinderStub();
}