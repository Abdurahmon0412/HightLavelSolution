using DependensyInjection.Models;
using DependensyInjection.Services.Interfaces;

namespace DependensyInjection.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;
        private readonly IEmailSenderServices _emailSenderService;

        public AccountService(IUserService userService, IEmailSenderServices emailSenderServices)
        {
            _emailSenderService = emailSenderServices;
            _userService = userService;
        }

        public async ValueTask<bool> RegisterAsync(RegisterDetails registerDetails)
        {
            var user = new User
            {
                EmailAddress = registerDetails.EamilAddress,
                Password = registerDetails.Password,
            };
            var createdUser = await _userService.CreateAsync(user);
            var result = await _emailSenderService.SendEmailAsync(createdUser.EmailAddress, "", "");
            
            return result;
        }
    }
}