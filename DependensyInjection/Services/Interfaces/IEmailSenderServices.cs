namespace DependensyInjection.Services.Interfaces
{
    public interface IEmailSenderServices
    {
        ValueTask<bool> SendEmailAsync(string email, string subject, string message);
    }
}
