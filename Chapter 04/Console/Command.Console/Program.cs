using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            EmployeeManager employeeManager = new(1);
            Recruitment recruitment = new();
            recruitment.Commands.Add(new CreateEmailCommand(employeeManager));
            recruitment.Commands.Add(new DesignIdentityCardCommand(employeeManager));
            recruitment.Commands.Add(new DesignVisitingCardCommand(employeeManager));
            recruitment.Invoke();
            Console.Read();
        }
    }
}
