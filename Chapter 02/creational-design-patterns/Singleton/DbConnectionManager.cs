public class DbConnectionManager
{
    /*Early Initialization*/
    //private static DbConnectionManager _instance = new();
    //private DbConnectionManager() { }
    //public static DbConnectionManager GetInstance() => _instance;

    /*Lazy Initialization*/
    private static DbConnectionManager _instance;
    private static object locker = new();
    private DbConnectionManager() { }
    public static DbConnectionManager GetInstance()
    {
        if (_instance != null)
            return _instance;
        lock (locker)
        {
            if (_instance == null)
                _instance = new();
            return _instance;
        }
    }
    //private static readonly Lazy<DbConnectionManager> lazy = new(() => new DbConnectionManager());
    //public static DbConnectionManager GetInstance()
    //{
    //    return lazy.Value;
    //}

    //[MethodImpl(MethodImplOptions.Synchronized)]
    //public static DbConnectionManager GetInstance()
    //{
    //    if (_instance == null)
    //        _instance = new();
    //    return _instance;
    //}
}