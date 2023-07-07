using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IGISService gisService = new GISServiceProxy();
            Console.WriteLine(gisService.GetLatLng("Urmia"));
            Console.WriteLine(gisService.GetLatLng("Tehran"));
            Console.WriteLine(gisService.GetLatLng("Urmia"));

            //Remote Proxy
            IRemoteService service = new RemoteProxy();
            Console.WriteLine(await service.GetAllAsync());
            Console.WriteLine(await service.GetAsync(2));
            Console.Read();
        }
    }
}
