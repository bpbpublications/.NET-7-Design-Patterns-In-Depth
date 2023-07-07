//using System;
//using System.Collections;
//using System.Linq;

//public class Profile
//{
//    public string Name { get; set; }
//    public string Email { get; set; }
//    public short Gender { get; set; }
//    public override string ToString() => $"Name: {Name}, Email: {Email}, Gender: {(Gender == 1 ? "Male" : "Female")}";
//}

////public class InstagramIterator : IEnumerator
////{
////    int _currentPosition = -1;
////    Profile[] _profiles;
////    public InstagramIterator(Profile[] profiles) => _profiles = profiles;
////    public object Current => _profiles[_currentPosition];
////    public bool MoveNext() => (++_currentPosition) < _profiles.Length;
////    public void Reset() => _currentPosition = -1;
////}

//public class InstagramCollection : IEnumerable
//{
//    private readonly short gender;
//    Profile[] Profiles => new Profile[] {
//                    new() { Name = "Vahid", Email = "john@instagram.com", Gender = 1 },
//                    new() { Name = "Narges", Email = "paul@instagram.com", Gender = 0 },
//                    new() { Name = "Reza", Email = "sara@instagram.com", Gender = 1 },
//                    new() { Name = "Hasan", Email = "antonio@instagram.com", Gender = 1 },
//                    new() { Name = "Maryam", Email = "liza@instagram.com", Gender = 0 }
//                };

//    public InstagramCollection(short gender) => this.gender = gender;

//    public IEnumerator GetEnumerator()
//    {
//        foreach (var item in Profiles.Where(x => x.Gender == gender))
//        {
//            yield return item;
//        }
//    }
//    //public IEnumerator GetEnumerator() => new InstagramIterator(Profiles.Where(x => x.Gender == gender).ToArray());
//}
