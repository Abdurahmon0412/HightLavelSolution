using DependensyInjection.Models;

namespace DependensyInjection.Services.Interfaces
{
    public interface IAccountService
    {
        ValueTask<bool> RegisterAsync(RegisterDetails registerDetails);
    }
}