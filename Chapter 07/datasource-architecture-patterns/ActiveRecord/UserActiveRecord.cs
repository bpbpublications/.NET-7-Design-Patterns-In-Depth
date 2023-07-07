using System.Data;
using System.Data.SqlClient;

public class UserActiveRecord
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public static UserActiveRecord Load(IDataReader reader)
    {
        return new UserActiveRecord()
        {
            UserName = reader["Username"].ToString(),
            Password = reader["Password"].ToString()
        };
    }
    public bool IsPasswordValid() => Password.Length > 6 && (Password.Contains('@') || Password.Contains('#'));
    public async Task<bool> ChangePasswordAsync()
    {
        if (IsPasswordValid())
        {
            return (await new SqlCommand($"" +
                $"UPDATE Users " +
                $"SET [Password] = N'{this.Password}' " +
                $"WHERE UserName = N'{this.UserName}'", DB.Connection).ExecuteNonQueryAsync()) > 0;
        }
        else
        {
            throw new Exception("The password is not strong enough.");
        }
    }
    public async Task<bool> IncreaseFailedLoginAttemptAsync()
    {
        return (await new SqlCommand($"" +
            $"UPDATE Users " +
            $"SET [FailedLoginAttempt] = [FailedLoginAttempt] + 1 " +
            $"WHERE UserName = N'{this.UserName}'", DB.Connection).ExecuteNonQueryAsync()) > 0;
    }
    public async Task<bool> ResetFailedLoginAttemptAsync()
    {
        return (await new SqlCommand($"" +
            $"UPDATE Users " +
            $"SET [FailedLoginAttempt] = 0 " +
            $"WHERE UserName = N'{this.UserName}'", DB.Connection).ExecuteNonQueryAsync()) > 0;
    }
    public async Task<int> GetFailedLoginAttemptAsync()
    {
        return (int)await new SqlCommand($"" +
            $"SELECT [FailedLoginAttempt] FROM Users " +
            $"WHERE UserName = N'{this.UserName}'", DB.Connection).ExecuteScalarAsync();
    }
    public async Task<bool> IsUserExistsAsync()
    {
        return ((int)await new SqlCommand($"" +
            $"SELECT COUNT(*) FROM Users " +
            $"WHERE [Password] = N'{this.Password}' AND UserName = N'{this.UserName}'", DB.Connection).ExecuteScalarAsync()) > 0;
    }

    public async Task<bool> LoginAsync()
    {
        var loginResult = await IsUserExistsAsync();
        if (loginResult == false)
        {
            await IncreaseFailedLoginAttemptAsync();
            if (await GetFailedLoginAttemptAsync() > 3)
            {
                throw new Exception("Your account has been locked.");
            }
        }
        else
        {
            await ResetFailedLoginAttemptAsync();
        }
        return loginResult;
    }
}