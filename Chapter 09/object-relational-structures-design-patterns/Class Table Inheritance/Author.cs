using System.Data;
using System.Data.SqlClient;

namespace ClassTableInheritance;
public class Author
{
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public async Task<IDataReader> GetAllAsync() => await new SqlCommand($"" +
          $"SELECT * " +
          $"FROM Authors", DB.Connection).ExecuteReaderAsync();
}
public class HourlyPaidAuthor : Author
{
    public int HourlyPaid { get; set; }
    public int HoursWorked { get; set; }
    public async Task<IDataReader> GetAllAsync() => await new SqlCommand($"" +
        $"SELECT * " +
        $"FROM Authors AS a " +
        $"INNER JOIN hourlyPaidAuthor as h" +
        $"ON a.AuthorId = h.AuthorId", DB.Connection).ExecuteReaderAsync();
}
public class MonthlyPaidAuthor : Author
{
    public int Salary { get; set; }
    public async Task<IDataReader> GetAllAsync() => await new SqlCommand($"" +
        $"SELECT * " +
        $"FROM Authors AS a " +
        $"INNER JOIN monthlyPaidAuthor as m" +
        $"ON a.AuthorId = m.AuthorId", DB.Connection).ExecuteReaderAsync();
}