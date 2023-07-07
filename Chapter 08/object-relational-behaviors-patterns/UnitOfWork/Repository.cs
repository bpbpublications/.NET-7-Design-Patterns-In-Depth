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

public class SampleDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("dotnet-design-patterns");
        base.OnConfiguring(optionsBuilder);
    }
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
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }
}