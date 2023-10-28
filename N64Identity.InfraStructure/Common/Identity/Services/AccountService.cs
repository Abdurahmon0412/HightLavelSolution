using N64Identity.Application.Common.Enums;
using N64Identity.Application.Common.Identity.Services;
using N64Identity.Application.Common.Notifications.Services;
using N64Identity.Domain.Entities;

namespace N64Identity.InfraStructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    public static readonly List<User> _users = new List<User>();

    private readonly IVerificationTokenGeneratorService _verificationTokenGeneratorService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;

    public AccountService(IVerificationTokenGeneratorService verificationTokenGeneratorService,
        IEmailOrchestrationService emailOrchestrationService)
    {
        _emailOrchestrationService = emailOrchestrationService;
        _verificationTokenGeneratorService = verificationTokenGeneratorService;
    }

    public List<User> Users => _users;


    public ValueTask<bool> VerificateAsyncs(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("Invalid verification token", nameof(token));

        var verificationTokenResult = _verificationTokenGeneratorService.DecodeToken(token);

        if(!verificationTokenResult.IsValid)
            throw new InvalidOperationException("Invalid verification token");

        var result = verificationTokenResult.token.Type switch
        {
            VerificationType.EmailAddressVerification => MarkEmailAsVerifiedAsync(verificationTokenResult.token.UserId),
            _ => throw new InvalidOperationException("This method is not intended to accept other types of tokens")
        };

        return result;
    }

    public async ValueTask<User> CreateUserAsync(User user)
    {
        _users.Add(user);

        var emailVerificationToken = _verificationTokenGeneratorService.GenerateToken(VerificationType.EmailAddressVerification, user.Id);

        await _emailOrchestrationService.SendAsync(user.EmailAddress, emailVerificationToken);

        return user;
    }

    private ValueTask<bool> MarkEmailAsVerifiedAsync(Guid userId)
    {
        var founderUser = _users.FirstOrDefault(user => user.Id == userId) ?? throw new InvalidOperationException();
        founderUser.IsEmailAddressVerified = true;

        return new ValueTask<bool> (founderUser.IsEmailAddressVerified);
    }
}
