using System;
public class Log
{
    public DateTime LogDate { get; set; }
    public string Result { get; set; }
    public string Message { get; set; }
}
public interface ILogger
{
    void Log(Log data);
}
public class TextLogger : ILogger
{
    public void Log(Log data) => Console.WriteLine($"Log to text: {data.LogDate}-{data.Result}-{data.Message}");
}
public class ElasticLogger : ILogger
{
    public void Log(Log data) => Console.WriteLine($"Log to elastic: {data.LogDate}-{data.Result}-{data.Message}");
}
public interface IServiceBus
{
    public ILogger Logger { get; set; }
    void Call(string url);
}
public class BasicBus : IServiceBus
{
    public ILogger Logger { get; set; }
    public void Call(string url)
    {
        Console.WriteLine($"Request sent to {url}");
        Logger.Log(new Log { LogDate = DateTime.Now, Result = "OK", Message = "Response received." });
    }
}
public class AdvanceBus : IServiceBus
{
    public ILogger Logger { get; set; }
    public void Call(string url)
    {
        if (new Uri(url).Scheme == "http")
            Logger.Log(new Log { LogDate = DateTime.Now, Result = "Failed", Message = "HTTP not supported!" });
        else
        {
            Console.WriteLine($"Request sent to {url}");
            Logger.Log(new Log { LogDate = DateTime.Now, Result = "OK", Message = "Response received." });
        }
    }
}