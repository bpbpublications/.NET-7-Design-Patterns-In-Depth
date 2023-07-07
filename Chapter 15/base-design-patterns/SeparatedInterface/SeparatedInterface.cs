
//same package
namespace Package
{
    public class Client
    {
        public IUnitOfWork UnitOfWork { get; set; }
    }
    public interface IUnitOfWork
    {
        bool Commit();
    }
    public class UnitOfWork : IUnitOfWork
    {
        public bool Commit() => true;
    }
}

//Multiple Packages
namespace Package01
{
    public class Client
    {
        public IUnitOfWork UnitOfWork { get; set; }
    }
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
namespace Package02
{
    public class UnitOfWork : Package01.IUnitOfWork
    {
        public bool Commit() => true;
    }
}