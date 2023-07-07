using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {

            new Client(new IranKhodro()).CreatePetrolCar();
            new Client(new Saipa()).CreateDieselCar();
   
            Console.Read();
        }
    }
}
