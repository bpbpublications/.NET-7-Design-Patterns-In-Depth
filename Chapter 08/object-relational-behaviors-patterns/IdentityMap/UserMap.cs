namespace IdentityMap
{
    public class UserDbSet
    {
        public static List<User> Users = new()
        {
            new User() { Id = 1, Username = "Vahid", Email = "vahid@gmail.com" },
            new User() { Id = 2, Username = "Ali", Email = "ali@yahoo.com" },
            new User() { Id = 3, Username = "Reza", Email = "reza@gmail.com" },
            new User() { Id = 4, Username = "Maryam", Email = "maryam@gmail.com" },
            new User() { Id = 5, Username = "Hassan", Email = "hassan@yahoo.com" }
        };
    }
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
    public class UserMap
    {
        private readonly Dictionary<int, User> _mappings = new();
        public void Add(User user)
        {
            if (!_mappings.ContainsKey(user.Id))
                _mappings.Add(user.Id, user);
        }
        public User? Get(int id)
        {
            if (_mappings.ContainsKey(id))
                return _mappings[id];
            return null;
        }

        public void Remove(int key)
        {
            if (_mappings.ContainsKey(key))
                _mappings.Remove(key);
        }
    }
    public interface IUserRepository
    {
        User Get(int id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly UserMap _usermap;
        public UserRepository() => _usermap = new UserMap();
        public User Get(int id)
        {
            var cachedUser = _usermap.Get(id);
            if (cachedUser == null)
            {
                var user = UserDbSet.Users.FirstOrDefault(x => x.Id == id);
                _usermap.Add(user);
                return user;
            }
            return cachedUser;
        }
    }
}
