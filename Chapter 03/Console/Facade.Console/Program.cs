using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            TicketInquiry ticketInquiry = new TicketInquiry();
            foreach (var item in ticketInquiry.Inquiry(new DateTime(2021, 01, 02), "Tehran", "Urmia"))
            {
                Console.WriteLine(item.ToString());
            }
            Console.Read();
        }
    }
}
