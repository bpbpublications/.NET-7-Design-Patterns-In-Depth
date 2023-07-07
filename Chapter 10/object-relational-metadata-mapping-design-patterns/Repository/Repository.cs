using Microsoft.EntityFrameworkCore;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => $"Id: {Id}, Name: {Name}";
}
public class BankAccount
{
    public int Id { get; set; }
    public int AccountNumber { get; set; }
}

/*Simple Repository*/
//public class UserDbSet
//{
//    public static List<User> Users = new()
//    {
//        new User() { Id = 1, Name = "Vahid" },
//        new User() { Id = 2, Name = "Ali" },
//        new User() { Id = 3, Name = "Reza" },
//        new User() { Id = 4, Name = "Maryam" },
//        new User() { Id = 5, Name = "Hassan" }
//    };
//}
//public interface IRepository
//{
//    User Find(int id);
//    List<User> GetAll();
//    void Add(User user);
//    void Update(User user);
//    void Delete(int id);
//}
//public class UserRepository : IRepository
//{
//    public void Add(User user)
//    {
//        if (UserDbSet.Users.All(x => x.Id != user.Id))
//            UserDbSet.Users.Add(user);
//    }

//    public void Delete(int id) => UserDbSet.Users.Remove(Find(id));

//    public User Find(int id)
//    {
//        UserDbSet.Users.ToDictionary(x => x.Id).TryGetValue(id, out User result);
//        return result;
//    }

//    public List<User> GetAll() => UserDbSet.Users;

//    public void Update(User user)
//    {
//        var originalUser = Find(user.Id);
//        if (originalUser != null)
//        {
//            originalUser.Name = user.Name;
//        }
//    }
//}

/*Generic Interface with Concerete implementation*/
//public class UserDbSet
//{
//    public static List<User> Users = new()
//    {
//        new User() { Id = 1, Name = "Vahid" },
//        new User() { Id = 2, Name = "Ali" },
//        new User() { Id = 3, Name = "Reza" },
//        new User() { Id = 4, Name = "Maryam" },
//        new User() { Id = 5, Name = "Hassan" }
//    };
//}
//public class BankAccountDbSet
//{
//    public static List<BankAccount> BankAccounts = new()
//    {
//        new BankAccount() { Id = 1, AccountNumber = 123456 },
//        new BankAccount() { Id = 2, AccountNumber = 987654 }
//    };
//}
//public interface IRepository<TEntity, TKey>
//{
//    TEntity Find(TKey id);
//    List<TEntity> GetAll();
//    void Add(TEntity user);
//    void Update(TEntity user);
//    void Delete(TKey id);
//}
//public class UserRepository : IRepository<User, int>
//{
//    public void Add(User user)
//    {
//        if (UserDbSet.Users.All(x => x.Id != user.Id))
//            UserDbSet.Users.Add(user);
//    }

//    public void Delete(int id) => UserDbSet.Users.Remove(Find(id));

//    public User Find(int id)
//    {
//        UserDbSet.Users.ToDictionary(x => x.Id).TryGetValue(id, out User result);
//        return result;
//    }

//    public List<User> GetAll() => UserDbSet.Users;

//    public void Update(User user)
//    {
//        var originalUser = Find(user.Id);
//        if (originalUser != null)
//        {
//            originalUser.Name = user.Name;
//        }
//    }
//}
//public class BankAccountRepository : IRepository<BankAccount, int>
//{
//    public void Add(BankAccount user)
//    {
//        if (BankAccountDbSet.BankAccounts.All(x => x.Id != user.Id))
//            BankAccountDbSet.BankAccounts.Add(user);
//    }

//    public void Delete(int id) => BankAccountDbSet.BankAccounts.Remove(Find(id));

//    public BankAccount Find(int id)
//    {
//        BankAccountDbSet.BankAccounts.ToDictionary(x => x.Id).TryGetValue(id, out BankAccount result);
//        return result;
//    }

//    public List<BankAccount> GetAll() => BankAccountDbSet.BankAccounts;

//    public void Update(BankAccount account)
//    {
//        var originalAccount = Find(account.Id);
//        if (originalAccount != null)
//        {
//            originalAccount.AccountNumber = account.AccountNumber;
//        }
//    }
//}

/*Generic Repository*/
public class SampleDbContext2 : DbContext
{
    public SampleDbContext2(DbContextOptions op) : base(op)
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
}
public class SampleDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
}
public interface IRepository<TEntity, TKey>
{
    TEntity Find(TKey id);
    List<TEntity> GetAll();
    void Add(TEntity user);
    void Update(TEntity user);
    void Delete(TKey id);
}
public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
{
    internal SampleDbContext _context;
    internal DbSet<TEntity> _dbSet;
    public GenericRepository(SampleDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual List<TEntity> GetAll() => _dbSet.ToList();
    public virtual TEntity Find(TKey id) => _dbSet.Find(id);
    public virtual void Add(TEntity entity) => _dbSet.Add(entity);
    public virtual void Delete(TKey id) => _dbSet.Remove(_dbSet.Find(id));
    public virtual void Update(TEntity entityToUpdate)
    {
        var entry = _dbSet.Attach(entityToUpdate);
        _context.Entry(entry).State = EntityState.Modified;
    }
}