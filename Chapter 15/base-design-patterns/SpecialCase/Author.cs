public class Author
{
    public virtual int AuthorId { get; set; }
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public override string ToString() => $"{FirstName} {LastName}";
}

public class AuthorNotFound : Author
{
    public override int AuthorId { get => -1; set { } }

    public override string FirstName { get => ""; set { } }

    public override string LastName { get => ""; set { } }
    public override string ToString() => "Author Not Found!";
}

public class AuthorRepository
{
    private readonly List<Author> authorList = new()
        {
            new Author
            {
                AuthorId = 1,
                FirstName = "Vahid",
                LastName = "Farahmandian"
            },
            new Author
            {
                AuthorId = 2,
                FirstName = "Ali",
                LastName = "Mohammadi"
            }
        };
    public Author Find(int authorId)
    {
        Author result = authorList.FirstOrDefault(x => x.AuthorId == authorId);
        if (result == null)
            return new AuthorNotFound();
        return result;
    }
}