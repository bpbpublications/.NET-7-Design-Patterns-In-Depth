using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            TicketContext context = new(new AssignState());
            context.Process();
            context.Process();
            context.Process();
            context.Process();
            Console.Read();
        }
    }
}
