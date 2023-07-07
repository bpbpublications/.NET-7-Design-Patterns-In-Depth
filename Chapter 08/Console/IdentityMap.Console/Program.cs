
using IdentityMap;

UserRepository userRepository = new UserRepository();
var user1 = userRepository.Get(1);
var user2 = userRepository.Get(1);
var user3 = userRepository.Get(3);
Console.WriteLine(user1.GetHashCode());
Console.WriteLine(user2.GetHashCode());
Console.WriteLine(user3.GetHashCode());

Console.ReadLine();