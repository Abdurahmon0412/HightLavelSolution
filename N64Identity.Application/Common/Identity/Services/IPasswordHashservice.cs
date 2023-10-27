namespace N64Identity.Application.Common.Identity.Services;

public interface IPasswordHashservice
{
    string HashPassword(string password);

    bool validatePassword(string password, string hashedPassword);
}