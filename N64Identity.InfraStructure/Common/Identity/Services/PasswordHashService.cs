using N64Identity.Application.Common.Identity.Services;
using BC = BCrypt.Net.BCrypt;

namespace N64Identity.InfraStructure.Common.Identity.Services;

public class PasswordHashService : IPasswordHashservice
{
    public string HashPassword(string password)
    {
        return BC.HashPassword(password);
    }

    public bool validatePassword(string password, string hashedPassword)
    {
        return BC.Verify(password, hashedPassword);
    }
}
