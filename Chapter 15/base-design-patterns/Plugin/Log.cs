using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;

public static class Environment
{
    public static string Name { get; set; }
}
public class ConfigModel
{
    public string Interface { get; set; }
    public string Implementation { get; set; }
    public string Assembly { get; set; }
}
public interface ILog
{
    public static ILog Instance = PluginFactory.GetPlugin(typeof(ILog));
    void Execute();
}
namespace Plugin
{
    public class TxtLogger : ILog
    {
        public void Execute()
            => File.AppendAllText(
                $"E:\\log\\{Guid.NewGuid()}.txt",
                $"Executed at: {DateTime.Now}");
    }
    public class SqlServerLogger : ILog
    {
        public void Execute()
            => new SqlCommand($"" +
                $"INSERT INTO log (Content) " +
                $"VALUES (N'Executed at {DateTime.Now}')",
                DB.Connection).ExecuteNonQuery();
    }
}
public class PluginFactory
{
    private static readonly List<ConfigModel> configs;
    static PluginFactory()
    {
        var jsonConfigs = JObject.Parse(File.ReadAllText(@$"Plugin/{Environment.Name}.props.json"));

        configs = JsonConvert.DeserializeObject<List<ConfigModel>>(jsonConfigs.SelectToken("logging").ToString());
    }
    public static ILog GetPlugin(Type @interface)
    {
        ConfigModel config = configs.FirstOrDefault(x => x.Interface == @interface.Name) ?? throw new Exception("Invalid interface");
        return (ILog)Activator.CreateInstance(config.Assembly, config.Implementation).Unwrap();
    }
}
public class AuthorService
{
    public static void Add()
    {
        ILog.Instance.Execute();
    }
}