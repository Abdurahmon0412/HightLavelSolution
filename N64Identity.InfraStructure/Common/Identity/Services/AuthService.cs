using N64Identity.Application.Common.Identity.Models;
using N64Identity.Application.Common.Identity.Services;
using N64Identity.Domain.Entities;
using System.Security.Authentication;

namespace N64Identity.InfraStructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly ITokenGeneratorService _tokenGeneratorService;
    private readonly IPasswordHashservice _passwordHashService;
    public AuthService(ITokenGeneratorService tokenGeneratorService, IPasswordHashservice passwordHashservice)
    {
        _tokenGeneratorService = tokenGeneratorService;
        _passwordHashService = passwordHashservice;
    }

    private static readonly List<User> _users = new();

    public ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Age = registrationDetails.Age,
            EmailAddress = registrationDetails.EmailAddress,
            Password = _passwordHashService.HashPassword(registrationDetails.Password),
        };

        _users.Add(user);

        return new ValueTask<bool>(true);
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var foundUser = _users.FirstOrDefault(user => user.EmailAddress == loginDetails.EmailAddress 
        && user.Password == loginDetails.Password);

        if (foundUser is null)
            throw new AuthenticationException("Login details are invalid, contact support.");

        var accessToken = _tokenGeneratorService.GetToken(foundUser);

        return new ValueTask<string>(accessToken);
    }
}