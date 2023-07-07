using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            InstagramCollection social = new InstagramCollection(0);
            Console.WriteLine("########All Profiles#######");
            foreach (var item in social.Profiles)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("########All Profiles by IEnumerator#######");
            var socialEnum = social.Profiles.GetEnumerator();
            while (socialEnum.MoveNext())
            {
                Console.WriteLine(socialEnum.Current);
            }
            Console.WriteLine("########Male Profiles#######");
            var profiles = social.CreateMaleIterator();
            while (profiles.HasNext())
            {
                Console.WriteLine(profiles.Next());
            }
            Console.WriteLine("########Reverse traversing#######");
            while (!profiles.IsFirst())
            {
                Console.WriteLine(profiles.Prev());
            }
            Console.Read();
        }
    }
}
