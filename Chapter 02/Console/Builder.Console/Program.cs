using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CellPhoneDirector director = new CellPhoneDirector(new Samsung());
            var phone = director.Construct();
            Console.WriteLine($"Body: {phone.BodyMaterial}, Camera: {phone.CameraResolution}, Monitor: {phone.MonitorSize}, OS: {phone.OSName}");

            director = new CellPhoneDirector(new Apple());
            phone = director.Construct();
            Console.WriteLine($"Body: {phone.BodyMaterial}, Camera: {phone.CameraResolution}, Monitor: {phone.MonitorSize}, OS: {phone.OSName}");

            Console.Read();
        }
    }
}
