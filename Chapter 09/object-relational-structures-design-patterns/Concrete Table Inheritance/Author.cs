using System.Data;
using System.Data.SqlClient;

namespace ConcreteTableInheritance;

public abstract class Author
{
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public abstract Task<IDataReader> GetAllAsync();
}
public class HourlyPaidAuthor : Author
{
    public int HourlyPaid { get; set; }
    public int HoursWorked { get; set; }
    public override async Task<IDataReader> GetAllAsync() => await new SqlCommand($"" +
        $"SELECT * " +
        $"FROM hourlyPaidAuthor", DB.Connection).ExecuteReaderAsync();
}
public class MonthlyPaidAuthor : Author
{
    public int Salary { get; set; }
    public override async Task<IDataReader> GetAllAsync() => await new SqlCommand($"" +
        $"SELECT * " +
        $"FROM monthlyPaidAuthor", DB.Connection).ExecuteReaderAsync();
}
