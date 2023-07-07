using System.Data;
using System.Data.SqlClient;

public static class UserFinder
{
    public static async Task<UserRowDataGateway> FindAsync(string username)
    {
        var reader = await new SqlCommand($"" +
           $"SELECT * " +
           $"FROM Users " +
           $"WHERE UserName = N'{username}'", DB.Connection).ExecuteReaderAsync();
        reader.Read();
        return UserRowDataGateway.Load(reader);
    }

    public static async Task<IList<UserRowDataGateway>> GetAllAsync()
    {
        var gatewayList = new List<UserRowDataGateway>();
        var reader = await new SqlCommand("SELECT * FROM Users", DB.Connection).ExecuteReaderAsync();
        while (reader.Read())
            gatewayList.Add(UserRowDataGateway.Load(reader));
        return gatewayList;
    }
}

public class UserRowDataGateway
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public static UserRowDataGateway Load(IDataReader reader)
    {
        return new UserRowDataGateway()
        {
            UserName = reader["Username"].ToString(),
            Password = reader["Password"].ToString()
        };
    }

    public async Task<bool> ChangePasswordAsync()
    {
        return (await new SqlCommand($"" +
            $"UPDATE Users " +
            $"SET [Password] = N'{this.Password}' " +
            $"WHERE UserName = N'{this.UserName}'", DB.Connection).ExecuteNonQueryAsync()) > 0;
    }
}