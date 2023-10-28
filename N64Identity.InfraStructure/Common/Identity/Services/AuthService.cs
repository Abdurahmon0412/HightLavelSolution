using N64Identity.Application.Common.Identity.Models;
using N64Identity.Application.Common.Identity.Services;
using N64Identity.Application.Common.Notifications.Services;
using N64Identity.Domain.Entities;
using System.Security.Authentication;

namespace N64Identity.InfraStructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly ITokenGeneratorService _tokenGeneratorService;
    private readonly IPasswordHashservice _passwordHashService;
    private readonly IAccountService _accountService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;

    public AuthService(
        ITokenGeneratorService tokenGeneratorService,
        IPasswordHashservice passwordHashservice,
        IAccountService accountService,
        IEmailOrchestrationService emailOrchestrationService)
    {
        _tokenGeneratorService = tokenGeneratorService;
        _passwordHashService = passwordHashservice;
        _accountService = accountService;
        _emailOrchestrationService = emailOrchestrationService;
    }

    private static readonly List<User> _users = new();

    public async ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var founderUser = _accountService.Users.FirstOrDefault(user => user.EmailAddress == registrationDetails.EmailAddress);

        if (founderUser is not null)
            throw new InvalidOperationException("User with this email address already exists.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Age = registrationDetails.Age,
            EmailAddress = registrationDetails.EmailAddress,
            Passwordhash = _passwordHashService.HashPassword(registrationDetails.Password),
        };
        await _accountService.CreateUserAsync(user);
        var verificationEmailresult = await _emailOrchestrationService.SendAsync(registrationDetails.EmailAddress, "Welcome to our System");

        return verificationEmailresult;
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var foundUser = _users.FirstOrDefault(user => user.EmailAddress == loginDetails.EmailAddress);
            

        if (foundUser is null || _passwordHashService.validatePassword(loginDetails.Password, foundUser.Passwordhash))
            throw new AuthenticationException("Login details are invalid, contact support.");

        var accessToken = _tokenGeneratorService.GetToken(foundUser);

        return new ValueTask<string>(accessToken);
    }
}