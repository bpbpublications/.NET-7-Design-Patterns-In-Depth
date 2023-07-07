using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IPant jean1 = new JeanPant()
            {
                Price = 10000,
                ClothInfo = new Cloth()
                {
                    Color = "Red"
                }
            };
            IPant cotton1 = new CottonPant()
            {
                Price = 7000,
                ClothInfo = new Cloth()
                {
                    Color = "Red"
                }
            };
            IPant fabric1 = new FabricPant()
            {
                Price = 12000,
                ClothInfo = new Cloth()
                {
                    Color = "Blue"
                }
            };
            PantRegistry registry = new PantRegistry();
            registry.Add(jean1);
            registry.Add(cotton1);
            registry.Add(fabric1);
            Console.WriteLine($"{jean1}");
            Console.WriteLine($"{registry.GetByType(typeof(JeanPant))}");
            Console.WriteLine($"{registry.GetByColor("Red")}");

            IPant jean2 = jean1.Clone();
            jean2.Price = 11000;
            jean2.ClothInfo.Color = "Geen";

            Console.WriteLine($"jean1: {jean1}");
            Console.WriteLine($"jean2: {jean2}");

            Console.Read();
        }
    }
}
