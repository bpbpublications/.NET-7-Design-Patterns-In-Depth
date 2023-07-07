using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DoorManufacturer manufacturer = new Carpenter();
            manufacturer.CreateDoor();
            DoorManufacturer manufacturer2 = new StarndardDoorManufacturer<WoodenDoor>();
            manufacturer.CreateDoor();

            Console.Read();
        }
    }
}
