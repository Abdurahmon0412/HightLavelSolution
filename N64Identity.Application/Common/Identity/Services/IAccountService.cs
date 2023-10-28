using N64Identity.Domain.Entities;

namespace N64Identity.Application.Common.Identity.Services;

public interface IAccountService
{
    List<User> Users { get; }

    ValueTask<bool> VerificateAsyncs(string token);

    ValueTask<User> CreateUserAsync(User user);
}