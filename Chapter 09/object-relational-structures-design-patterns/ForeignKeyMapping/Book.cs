namespace ForeignKeyMapping;

public class Book
{
    private BookDetail detail;
    private ICollection<Comment> comments = new List<Comment>();

    public int BookId { get; set; }
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
    public ICollection<Comment> Comments
    {
        get => comments; set
        {
            comments = value;
            foreach (var item in comments.Where(x => x.Book == null)) item.Book = this;
        }
    }
    public BookDetail Detail
    {
        get => detail; set
        {
            detail = value;
            if (detail.Book == null) detail.Book = this;
        }
    }
}
public class Comment
{
    public int CommentId { get; set; }
    public string Text { get; set; }

    private Book book;
    public Book Book
    {
        get => book; set
        {
            book = value;
            if (!book.Comments.Contains(this))
                book.Comments.Add(this);
        }
    }
}

public class BookDetail
{
    public int BookId { get; set; }
    public byte[] File { get; set; }
    public Book Book { get; set; }
}
