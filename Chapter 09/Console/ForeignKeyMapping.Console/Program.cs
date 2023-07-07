using ForeignKeyMapping;

var book = new Book()
{
    BookId = 1,
    Title = "Design Patterns in .NET",
    PublishDate = new DateOnly(2020, 10, 01),
    Detail = new BookDetail
    {
        BookId = 1,
        File = Array.Empty<byte>()
    },
    Comments = new List<Comment>()
    {
        new Comment()
        {
            CommentId = 1,
            Text = "good book"
        }
    }
};

var comment2 = new Comment
{
    CommentId = 2,
    Book = book,
    Text = "how can I buy this book?"
};

Console.ReadLine();