using System.Linq;

public class Profile
{
    public string Name { get; set; }
    public string Email { get; set; }
    public short Gender { get; set; }
    public override string ToString() => $"Name: {Name}, Email: {Email}, Gender: {(Gender == 1 ? "Male" : "Female")}";
}
public abstract class ProfileIterator
{
    protected int _currentPosition;
    protected Profile[] _profiles;

    public virtual Profile First()
    {
        _currentPosition = 0;
        return _profiles[_currentPosition];
    }

    public virtual Profile Last()
    {
        _currentPosition = _profiles.Length - 1;
        return _profiles[_currentPosition];
    }

    public virtual Profile Next() => _profiles[_currentPosition++];
    public virtual Profile Prev() => _profiles[--_currentPosition];
    public virtual bool HasNext() => _currentPosition < _profiles.Length;
    public virtual bool IsFirst() => _currentPosition == 0;
}
public class LinkedInIterator : ProfileIterator
{
    public LinkedInIterator(LinkedInCollection linkedIn, short gender) =>
        _profiles = linkedIn.Profiles.Where(x => x.Gender == gender).ToArray();
}
public class InstagramIterator : ProfileIterator
{
    public InstagramIterator(InstagramCollection instagram, short gender) =>
        _profiles = instagram.Profiles.Where(x => x.Gender == gender).ToArray();
}
public interface ISocialNetworkCollection
{
    ProfileIterator CreateMaleIterator();
    ProfileIterator CreateFemaleIterator();
}
public class LinkedInCollection : ISocialNetworkCollection
{
    public Profile[] Profiles => new Profile[] {
                    new() { Name="John", Email="john@linkedin.com", Gender = 1},
                    new() { Name="Paul", Email="paul@linkedin.com", Gender = 1},
                    new() { Name="Sara", Email="sara@linkedin.com", Gender = 0},
                    new() { Name="Antonio", Email="antonio@linkedin.com", Gender = 1},
                    new() { Name="Liza", Email="liza@linkedin.com", Gender = 0}
                };
    public ProfileIterator CreateMaleIterator() => new LinkedInIterator(this, 1);

    public ProfileIterator CreateFemaleIterator() => new LinkedInIterator(this, 0);
}
public class InstagramCollection : ISocialNetworkCollection
{
    private readonly short gender;
    public InstagramCollection(short gender) => this.gender = gender;
    public Profile[] Profiles => new Profile[] {
                    new() { Name = "Vahid", Email = "john@instagram.com", Gender = 1 },
                    new() { Name = "Narges", Email = "paul@instagram.com", Gender = 0 },
                    new() { Name = "Reza", Email = "sara@instagram.com", Gender = 1 },
                    new() { Name = "Hasan", Email = "antonio@instagram.com", Gender = 1 },
                    new() { Name = "Maryam", Email = "liza@instagram.com", Gender = 0 }
                };
    public ProfileIterator CreateMaleIterator() => new InstagramIterator(this, 1);

    public ProfileIterator CreateFemaleIterator() => new InstagramIterator(this, 0);
}
