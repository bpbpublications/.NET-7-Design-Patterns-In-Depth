using System.Data.SqlClient;

var reader = await new SqlCommand("SELECT * FROM Users Where ID = 1", DB.Connection).ExecuteReaderAsync();
var user = UserActiveRecord.Load(reader);
await user.LoginAsync();

Console.ReadLine();