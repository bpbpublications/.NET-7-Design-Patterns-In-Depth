using System;
using System.Collections.Generic;

public class Shoe
{
    public int Size { get; set; }
    public string Color { get; set; }
}
public interface IShoeObserver
{
    void Update(Shoe param);
}
public class CustomerObserver : IShoeObserver
{
    public void Update(Shoe param) => Console.WriteLine("Sending email to customer...");
}
public class LoggingObserver : IShoeObserver
{
    public void Update(Shoe param) => Console.WriteLine("Saving log...");
}
public interface IShoeNotifier
{
    void Subscribe(IShoeObserver param);
    void Unsubscribe(IShoeObserver param);
    void Notify(Shoe param);
}
public class ShoeNotifier : IShoeNotifier
{
    private static List<IShoeObserver> _subscribers;
    static ShoeNotifier() => _subscribers = new List<IShoeObserver>();
    public void Subscribe(IShoeObserver param) => _subscribers.Add(param);
    public void Unsubscribe(IShoeObserver param) => _subscribers.Remove(param);
    public void Notify(Shoe param)
    {
        foreach (var item in _subscribers)
            item.Update(param);
    }
}

/*Observer with ChangeManager*/
/*
public class Shoe
{
    public int Size { get; set; }
    public string Color { get; set; }
}
public interface IShoeObserver
{
    void Update(Shoe param);
}
public class CustomerObserver : IShoeObserver
{
    public void Update(Shoe param) => Console.WriteLine("Sending email to customer...");
}
public class LoggingObserver : IShoeObserver
{
    public void Update(Shoe param) => Console.WriteLine("Saving log...");
}
public interface IShoeNotifier
{
    void Subscribe(IShoeObserver param);
    void Unsubscribe(IShoeObserver param);
    void Notify(Shoe param);
}
public class ShoeNotifier : IShoeNotifier
{
    private ChangeManager _changeManager;
    public ShoeNotifier() => _changeManager = ChangeManager.GetInstance();
    public void Subscribe(IShoeObserver param) => _changeManager.Register(this, param);
    public void Unsubscribe(IShoeObserver param) => _changeManager.Unregister(this, param);
    public void Notify(Shoe param)
    {
        _changeManager.Notify(param);
    }
}
public class Mapping
{
    public IShoeNotifier Notifier { get; set; }
    public IShoeObserver Observer { get; set; }
}
public class ChangeManager
{
    private ChangeManager() { }
    private static readonly object _lock = new();
    private static ChangeManager _instance;
    public static ChangeManager GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new ChangeManager();
            }
        }
        return _instance;
    }
    static List<Mapping> mappings = new();
    public void Register(IShoeNotifier notifier, IShoeObserver observer)
    {
        if (!mappings.Any(x => x.Notifier == notifier && x.Observer == observer))
            mappings.Add(new Mapping { Notifier = notifier, Observer = observer });
    }
    public void Unregister(IShoeNotifier notifier, IShoeObserver observer)
    {
        var map = mappings.FirstOrDefault(x => x.Notifier == notifier && x.Observer == observer);
        if (map != null)
            mappings.Remove(map);
    }
    public void Notify(Shoe param)
    {
        foreach (var item in mappings)
        {
            item.Observer.Update(param);
        }
    }
}
 */
