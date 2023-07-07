using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Invoice invoice = new(new GoldenUsersVisitor());
            invoice.Items.Add(new Food() { Cost = 100 });
            invoice.Items.Add(new Cosmetics() { Cost = 150 });
            invoice.Items.Add(new HomeAppliances() { Cost = 1000 });
            Console.WriteLine($"Total: {invoice.Calculate()}");
            Console.Read();
        }
    }
}
