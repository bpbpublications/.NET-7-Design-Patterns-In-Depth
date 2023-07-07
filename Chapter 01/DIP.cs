using System.Collections.Generic;

namespace DotNet_Design_Patterns.Chapter1.SOLID.DIP
{
    public class User
    {
        private readonly IEmailService _emailService;
        public string FirstName { get; set; }
        public string Email { get; set; }
        public static List<User> Users { get; set; } = new List<User>();
        public User(IEmailService emailService) => this._emailService = emailService;
        public void NewUser(User user)
        {
            Users.Add(user);
            _emailService.SendEmail(user.Email, "Account Created", "Your new account created");
        }
    }
    public interface IEmailService
    {
        void SendEmail(string email, string subject, string body);
    }
    public class EmailService : IEmailService
    {
        public void SendEmail(string email, string subject, string body)
        {
            //ارسال ایمیل به گیرنده مورد نظر
        }
    }

}
