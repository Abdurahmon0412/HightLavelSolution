using N53_TakeToken.Models.Dtos;
using N53_TakeToken.Models.Entities;
using System.Security.Authentication;

namespace N53_TakeToken.Services;

public class AuthService
{
    private readonly TokenGeneratorService _tokenGeneratorService;

    public AuthService(TokenGeneratorService tokenGeneratorService) => _tokenGeneratorService = tokenGeneratorService;

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
            Password = registrationDetails.Password,
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