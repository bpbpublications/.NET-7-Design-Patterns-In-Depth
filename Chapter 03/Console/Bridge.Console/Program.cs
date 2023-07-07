using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IServiceBus bus = new BasicBus()
            {
                Logger = new TextLogger()
            };
            bus.Call("https://google.com");
            Console.Read();
        }
    }
}
