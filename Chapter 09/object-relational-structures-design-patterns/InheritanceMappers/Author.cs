using System.Data;
using System.Data.SqlClient;

namespace InheritanceMappers;
public abstract class Author
{
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
public class HourlyPaidAuthor : Author
{
    public int HourlyPaid { get; set; }
    public int HoursWorked { get; set; }
}
public class MonthlyPaidAuthor : Author
{
    public int Salary { get; set; }
}

public abstract class AuthorMapper
{
    private readonly string tableName;
    public AuthorMapper(string tableName) => this.tableName = tableName;
    protected string GetUpdateStatementById(Author author)
    {
        return $"UPDATE {tableName} " +
            $"SET FirstName = N'{author.FirstName}', LastName = N'{author.LastName}' " +
            $"#UpdateToken# " +
            $"WHERE AuthorId = {author.AuthorId}";
    }
    public string GetDeleteStatementById(int authorId) => $"DELETE FROM {tableName} WHERE AuthorId = {authorId}";
    protected async Task<bool> SaveAsync(string query) => await new SqlCommand(query, DB.Connection).ExecuteNonQueryAsync() > 0;
    public virtual async Task DeleteAsync(int authorId)
        => await SaveAsync(GetDeleteStatementById(authorId));
}
public class HourlyPaidAuthorMapper : AuthorMapper
{
    public HourlyPaidAuthorMapper() : base("hourlyPaidAuthor") { }
    protected HourlyPaidAuthor Load(IDataReader reader)
    {
        return new HourlyPaidAuthor()
        {
            AuthorId = (int)reader["AuthorId"],
            FirstName = (string)reader["FirstName"],
            LastName = (string)reader["LastName"],
            HourlyPaid = (int)reader["HourlyPaid"],
            HoursWorked = (int)reader["HoursWorked"]
        };
    }
    public async Task<List<HourlyPaidAuthor>> GetAllAsync()
    {
        var result = new List<HourlyPaidAuthor>();
        var reader = await new SqlCommand($"" +
            $"SELECT * " +
            $"FROM hourlyPaidAuthor", DB.Connection).ExecuteReaderAsync();
        while (reader.Read())
            result.Add(Load(reader));
        return result;
    }
    public async Task UpdateAsync(HourlyPaidAuthor obj)
        => await SaveAsync(base.GetUpdateStatementById(obj)
            .Replace("#UpdateToken#", $"HoursWorked = {obj.HoursWorked}"));
}
public class MonthlyPaidAuthorMapper : AuthorMapper
{
    public MonthlyPaidAuthorMapper() : base("monthlyPaidAuthor") { }
    protected MonthlyPaidAuthor Load(IDataReader reader)
    {
        return new MonthlyPaidAuthor()
        {
            AuthorId = (int)reader["AuthorId"],
            FirstName = (string)reader["FirstName"],
            LastName = (string)reader["LastName"],
            Salary = (int)reader["Salary"]
        };
    }
    public async Task<List<MonthlyPaidAuthor>> GetAllAsync()
    {
        var result = new List<MonthlyPaidAuthor>();
        var reader = await new SqlCommand($"" +
            $"SELECT * " +
            $"FROM monthlyPaidAuthor", DB.Connection).ExecuteReaderAsync();
        while (reader.Read())
            result.Add(Load(reader));
        return result;
    }
    public async Task UpdateAsync(MonthlyPaidAuthor obj)
        => await SaveAsync(base.GetUpdateStatementById(obj)
            .Replace("#UpdateToken#", $"Salary = {obj.Salary}"));
}
