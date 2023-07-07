using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IShoeObserver customerObserver = new CustomerObserver();
            IShoeObserver loggingObserver = new LoggingObserver();

            IShoeNotifier notifier = new ShoeNotifier();
            notifier.Subscribe(customerObserver);
            notifier.Subscribe(loggingObserver);
            notifier.Notify(new Shoe { Size = 45, Color = "Red" });
            //ChangeManager.GetInstance().Notify(new Shoe { Size = 45, Color = "Red" });
            Console.Read();
        }
    }
}
