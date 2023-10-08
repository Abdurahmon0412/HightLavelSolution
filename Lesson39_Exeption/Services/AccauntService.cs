using Lesson40_Exeption.Models;
using System.Text.RegularExpressions;

namespace Lesson40_Exeption.Services
{
    public class AccauntService
    {
        private List<User> _users = new List<User>();
        private List<Email> _emails = new List<Email>();

        public AccauntService()
        {
            
        }
        public void RegisterAsync(string emailAddress, string password)
        {
            //if (!Regex.IsMatch(emailAddress, @"^[a-zA-Z]{4,}[a-zA-Z0-9]*
            //    (\.[a-zA-Z0-9]{4,})*@[a-zA-Z0-9]{4,}\.[a-zA-Z]{2,}[a-zA-Z]*$"))
            //{
            //    throw new ArgumentOutOfRangeException(nameof(emailAddress));
            //}
            if(string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentOutOfRangeException(nameof(emailAddress));
            }
            if (string.IsNullOrWhiteSpace(password) || password.Length < 4)
            {
                throw new ArgumentOutOfRangeException("Password is Invalid");
            }
            if (_users.Any(email => email.EmailAddress.Equals(emailAddress)))
            {
                throw new InvalidOperationException("This User already exists");
            }
            _users.Add(new User { EmailAddress = emailAddress, Password = password });
        }
    }
}
