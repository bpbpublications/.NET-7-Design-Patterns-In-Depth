namespace RemoteFacade
{
    public interface IAuthorService
    {
        void AddAuthor(AuthorDTO dto);
        ICollection<AuthorDTO> GetAuthors();
    }
    public class AuthorService : IAuthorService
    {
        public void AddAuthor(AuthorDTO dto) => new AuthorAssembler().CreateAuthor(dto);

        public ICollection<AuthorDTO> GetAuthors() => new AuthorAssembler().GetAuthors();
    }
    public class AuthorAssembler
    {
        public AuthorDTO ToDTO(Author author)
        {
            AuthorDTO dto = new()
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };
            ConvertBooks(dto, author);
            return dto;
        }
        public void ConvertBooks(AuthorDTO dto, Author model)
        {
            foreach (var book in model.Books)
            {
                dto.Books.Add(new BookDTO
                {
                    Title = book.Title,
                    Language = book.Language
                });
            }
        }
        public Author ToModel(AuthorDTO author)
        {
            Author dto = new()
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };
            ConvertBooks(dto, author);
            return dto;
        }
        public void ConvertBooks(Author model, AuthorDTO dto)
        {
            foreach (var book in dto.Books)
            {
                model.Books.Add(new Book
                {
                    Title = book.Title,
                    Language = book.Language
                });
            }
        }
        public void CreateAuthor(AuthorDTO dto)
        {
            Author author = ToModel(dto);
            author.AuthorId = new Random().Next(1, 100);
            CreateBooks(dto.Books, author);
        }
        private void CreateBooks(ICollection<BookDTO> dtos, Author author)
        {
            if (dtos != null)
            {
                if (dtos.Any(x => string.IsNullOrWhiteSpace(x.Title)))
                    throw new Exception("Book title cannot be null or empty");
                foreach (var item in dtos)
                {
                    var book = new Book
                    {
                        Title = item.Title,
                        Language = item.Language,
                        BookId = new Random().Next(1, 100)
                    };
                    author.Books.Add(book);
                }
            }
        }
        public List<AuthorDTO> GetAuthors() => DatabaseGateway.GetAuthors().Select(x => ToDTO(x)).ToList();
    }
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Book> Books { get; set; }
    }
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
    public class AuthorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<BookDTO> Books { get; set; }
    }
    public class BookDTO
    {
        public string Title { get; set; }
        public string Language { get; set; }
    }
    public class DatabaseGateway
    {
        public static void CreateAuthor(Author model)
        {
            //create author and its related books
        }
        public static void CreateBooks(ICollection<Book> model)
        {
            //create book
        }
        public static List<Author> GetAuthors()
        {
            List<Author> authors = new()
            {
                new Author()
                {
                    AuthorId = 1,
                    FirstName="Vahid",
                    LastName="Farahmandian",
                    IsActive =true,
                    Books = new List<Book>
                    {
                        new Book
                    {
                        BookId = 1,
                        Language = "fa",
                        Title = "Design Patterns in .NET"
                    }
                    }
                },
                new Author()
                {
                    AuthorId = 2,
                    FirstName="Ali",
                    LastName="Ahmadi",
                    IsActive =true,
                    Books = new List<Book>
                    {
                        new Book
                        {
                            BookId = 2,
                            Language = "fa",
                            Title = "C# Programming"
                        },
                        new Book
                        {
                            BookId = 3,
                            Language = "fa",
                            Title = "Querying Microsoft SQL Server"
                            }
                    }
                }
            };
            return authors;
        }
    }
}