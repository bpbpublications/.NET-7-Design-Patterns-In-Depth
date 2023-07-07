public partial class AuthorsList //: System.Web.UI.Page
{
    protected List<Author> Authors { get; set; }
    protected Author BestAuthor { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        //var helper = new AuthorHelper();
        //Authors = helper.GetAuthors();
        //authorsGrid.DataSource = Authors;
        //authorsGrid.DataBind();
        //BestAuthor = Authors.OrderByDescending(x => x.BooksCount).FirstOrDefault();
        //firstname.DataBind();
        //lastname.DataBind();
    }
}
public class Author
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int BooksCount { get; set; }
}
public class AuthorHelper
{
    public List<Author> GetAuthors()
    {
        return new List<Author>()
            {
                new Author
                {
                    FirstName="Vahid",
                    LastName="Farahmandian",
                    BooksCount=2
                },
                new Author
                {
                    FirstName="Ali",
                    LastName="Rahimi",
                    BooksCount=1
                },
                new Author
                {
                    FirstName="Hassan",
                    LastName="Abbasi",
                    BooksCount=3
                }
            };
    }
}