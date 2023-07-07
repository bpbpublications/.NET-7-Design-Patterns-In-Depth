using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DataReader reader = new CSVReader();
            reader.Import();
            Console.Read();
        }
    }
}
