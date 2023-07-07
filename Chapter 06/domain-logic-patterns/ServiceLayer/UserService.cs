public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}
public class UserDbSet
{
    public static List<User> Users = new()
        {
            new User { Username = "user1", Password = "qwerty" },
            new User { Username = "user2", Password = "poiuyt" },
            new User { Username = "user3", Password = "mkoijn" }
        };
}
public interface IRepository
{
    void Insert(User user);
    User FindByUserName(string username);
}
public class UserRepository : IRepository
{
    public User FindByUserName(string username) => UserDbSet.Users.FirstOrDefault(x => x.Username == username);

    public void Insert(User user) => UserDbSet.Users.Add(user);
}
public interface IUserService
{
    void Add(User user);
}
public class UserService : IUserService
{
    private readonly IRepository _repository;
    public UserService() => _repository = new UserRepository();
    protected bool IsValid(User user) => _repository.FindByUserName(user.Username) == null;
    public void Add(User user)
    {
        if (IsValid(user))
            _repository.Insert(user);
        else
            throw new Exception("User exists!");
    }
}