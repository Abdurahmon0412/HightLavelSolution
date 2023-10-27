using System.Security.Claims;
using N64Identity.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace N64Identity.Application.Common.Identity.Services;

public interface ITokenGeneratorService
{
    string GetToken(User user);

    JwtSecurityToken GetJwtToken(User user);

    List<Claim> GetClaims(User user);

}