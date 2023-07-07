using System.Data;
using System.Data.SqlClient;

namespace SingleTableInheritance;

public abstract class Author
{
    private readonly string discriminator;
    protected Author(string discriminator) => this.discriminator = discriminator;
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    protected async Task<IDataReader> GetAllAsync() => await new SqlCommand($"" +
          $"SELECT * " +
          $"FROM Authors " +
          $"WHERE Discriminator = N'{discriminator}'", DB.Connection).ExecuteReaderAsync();
}
public class HourlyPaidAuthor : Author
{
    public HourlyPaidAuthor() : base(nameof(HourlyPaidAuthor)) { }
    public int HourlyPaid { get; set; }
    public int HoursWorked { get; set; }
    public async Task<List<HourlyPaidAuthor>> ReadAllAsync()
    {
        var result = new List<HourlyPaidAuthor>();
        var reader = await base.GetAllAsync();
        while (reader.Read())
            result.Add(new HourlyPaidAuthor
            {
                AuthorId = (int)reader["AuthorId"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                HourlyPaid = (int)reader["HourlyPaid"],
                HoursWorked = (int)reader["HoursWorked"]
            });
        return result;
    }
}
public class MonthlyPaidAuthor : Author
{
    public MonthlyPaidAuthor() : base(nameof(MonthlyPaidAuthor)) { }
    public int Salary { get; set; }
    public async Task<List<MonthlyPaidAuthor>> ReadAllAsync()
    {
        var result = new List<MonthlyPaidAuthor>();
        var reader = await base.GetAllAsync();
        while (reader.Read())
            result.Add(new MonthlyPaidAuthor
            {
                AuthorId = (int)reader["AuthorId"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                Salary = (int)reader["Salary"]
            });
        return result;
    }
}
