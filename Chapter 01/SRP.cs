using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Design_Patterns.Chapter1.SOLID
{
    public class WrongSRP
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public static List<WrongSRP> Users { get; set; } = new List<WrongSRP>();
        public void NewUser(WrongSRP User)
        {
            Users.Add(User);
            SendEmail(User.Email, "Account Created", "Your new account created");
        }
        public void SendEmail(string email, string subject, string body)
        {
            //Send Email to given email address
        }
    }

    public class SRP
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public static List<WrongSRP> Users { get; set; } = new List<WrongSRP>();
        public void NewUser(WrongSRP User)
        {
            Users.Add(User);
            new EmailService().SendEmail(User.Email, "Account Created", "Your new account created");
        }
    }
    public class EmailService
    {
        public void SendEmail(string email, string subject, string body)
        {
            //Send Email to given email address
        }
    }
}
