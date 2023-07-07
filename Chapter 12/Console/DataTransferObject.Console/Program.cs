
var author = new Author()
{
    FirstName = "Vahid",
    LastName = "Farahmandian",
    AuthorId = 1,
    IsActive = true,
    Books = new List<Book>
    {
        new Book
        {
            BookId=1,
            Title="Design Patterns in .NET",
            Language="fa"
        },
        new Book
        {
            BookId=2,
            Title="Programming in C#",
            Language="fa"
        }
    }
};
var t = author.ToDTO();
var y = t.ToModel();
Console.ReadLine();