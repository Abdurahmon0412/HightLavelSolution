using N64Identity.Application.Common.Enums;
using N64Identity.Application.Common.Identity.Models;

namespace N64Identity.Application.Common.Identity.Services;

public interface IVerificationTokenGeneratorService
{
    string GenerateToken(VerificationType type, Guid userId);

    (VerificationToken token, bool IsValid) DecodeToken(string  token);
}