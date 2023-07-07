using System.Data.SqlClient;

public class UserModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
public class UserMapper
{
    public static async Task<bool> Create(UserModel newUser)
    {
        return (await new SqlCommand($"" +
            $"INSERT INTO Users " +
            $"(Username, [Password]) VALUES " +
            $" N'{newUser.UserName}', N'{newUser.Password}'", DB.Connection).ExecuteNonQueryAsync()) > 0;

    }
}
public class UserDomain
{
    public static bool IsPasswordValid(string password) => password.Length > 6 && (password.Contains('@') || password.Contains('#'));
    public static async Task<bool> Register(string username, string password)
    {
        if (IsPasswordValid(password))
        {
            return await UserMapper.Create(new UserModel { UserName = username, Password = password });
        }
        else
        {
            throw new Exception("رمز عبور استحکام کافی را ندارد");
        }
    }
}