using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using N64Identity.Application.Common.Enums;
using N64Identity.Application.Common.Identity.Models;
using N64Identity.Application.Common.Identity.Services;
using N64Identity.Application.Common.Settings;
using Newtonsoft.Json;

namespace N64Identity.InfraStructure.Common.Identity.Services;

public class VerificationTokenGeneratorService : IVerificationTokenGeneratorService
{
    private readonly IDataProtector _protector;
    private readonly VerificationTokenSettings _verificationTokenSettings;

    public VerificationTokenGeneratorService(IOptions<VerificationTokenSettings> verificationTokenSettings,
        IDataProtectionProvider dataProtectionProvider)
    {
        _verificationTokenSettings = verificationTokenSettings.Value;
        _protector = dataProtectionProvider.CreateProtector(_verificationTokenSettings.IdentityVerificationTokenPurpose);
    }

    public string GenerateToken(VerificationType type, Guid userId)
    {
        var verificationToken = new VerificationToken
        {
            UserId = userId,
            Type = type,
            ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(_verificationTokenSettings.IdentityVerificationExpirationDurationInMinutes)
        };

        return _protector.Protect(JsonConvert.SerializeObject(verificationToken));
    }

    public (VerificationToken token, bool IsValid) DecodeToken(string token)
    {
        if(string.IsNullOrWhiteSpace(token))
            throw new ArgumentNullException(nameof(token));

        var unProtectedToken = _protector.Unprotect(token);
        var verificationToken = JsonConvert.DeserializeObject<VerificationToken>(unProtectedToken)??
            throw new ArgumentException("invalid verification modle", nameof(token));

        return (verificationToken, verificationToken.ExpiryTime >  DateTimeOffset.UtcNow);
    }
}