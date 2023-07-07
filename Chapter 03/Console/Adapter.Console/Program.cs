using Adapter;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {

            /* Pluggable Adapter
            Adapter adapter1 = new(new Adaptee());
            adapter1.Request("Hello Vahid");

            Adapter adapter2 = new(new Target());
            adapter2.Request("Hi my name is Vahid");
            */

            //IExternalService service = new ExternalService();
            //service.Url = "http://something.com/api/user";
            //service.Get("pageIndex = 1");

            IExternalService service = new ServiceAdapter();
            service.Url = "http://something.com/api/user";
            service.Get("pageIndex=1");
            service.Post(null);
            Console.Read();
        }
    }
}
