using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Parallel.Invoke(
                () =>
                {
                    DbConnectionManager obj1 = DbConnectionManager.GetInstance();
                    Console.WriteLine($"obj1: {obj1.GetHashCode()}");
                },
                () =>
                {
                    DbConnectionManager obj2 = DbConnectionManager.GetInstance();
                    Console.WriteLine($"obj2: {obj2.GetHashCode()}");
                });
            DbConnectionManager obj1 = DbConnectionManager.GetInstance();
            DbConnectionManager obj2 = DbConnectionManager.GetInstance();
            Console.WriteLine($"obj1: {obj1.GetHashCode()}, obj2: {obj2.GetHashCode()}");

            Console.Read();
        }
    }
}
