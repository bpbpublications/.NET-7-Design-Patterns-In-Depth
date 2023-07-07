using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            RequestHandler authenticationHandler = new AuthenticationHandler();
            RequestHandler authorizationHandler = new AuthorizationHandler();
            RequestHandler loggingHandler = new LoggingHandler();
            authenticationHandler.ContinueWith(authorizationHandler);
            authorizationHandler.ContinueWith(loggingHandler);
            authenticationHandler.Handle(new Request
            {
                IP = "10.168.1.1",
                Username = "vahid",
                Url = "http://abc.com/get"
            });
            Console.Read();
        }
    }
}
