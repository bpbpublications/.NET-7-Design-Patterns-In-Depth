namespace IdentityField;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
}

public class BookMapper
{
    public bool Create(Book book)
    {
        book.BookId = GetNewBookId();
        return Save(book);
    }

    private int GetNewBookId()
    {
        /*
          In this section, the desired method to generate the new value of the key must be implemented.
        */

        return 1;
    }
    private bool Save(Book book) { return true; }

    public Book Get()
    {
        Book book1 = new()
        {
            BookId = 1,
            Title = "Design Patterns in .NET",
            PublishDate = new DateOnly(2021, 10, 01)
        };
        return book1;
    }
}

public class CompoundKey
{
    private object[] keys;
    public CompoundKey(object[] keys) => this.keys = keys;
    public override bool Equals(object? obj)
    {
        if (obj is not CompoundKey)
            return false;
        CompoundKey other = (CompoundKey)obj;
        if (keys.Length != other.keys.Length)
            return false;
        for (int i = 0; i < keys.Length; i++)
            if (!keys[i].Equals(other.keys[i])) return false;

        return true;
    }
}
