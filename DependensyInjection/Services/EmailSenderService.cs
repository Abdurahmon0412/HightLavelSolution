using DependensyInjection.Services.Interfaces;

namespace DependensyInjection.Services
{
    public class EmailSenderService : IEmailSenderServices
    {
        public ValueTask<bool> SendEmailAsync(string email, string subject, string message)
        {
            return new(true);
        }
    }
}