using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using N64Identity.Domain.Entities;
using N64Identity.Application.Common.Constants;
using N64Identity.Application.Common.Identity.Services;
using N64Identity.Application.Common.Settings;
using Microsoft.Extensions.Options;

namespace N64Identity.InfraStructure.Common.Identity.Services;

public class TokenGeneratorService : ITokenGeneratorService
{
    private readonly JwtSettings _jwtSettings;

    public TokenGeneratorService(IOptions<JwtSettings> jwtSettings) => _jwtSettings = jwtSettings.Value;

    public string GetToken(User user)
    {
        var jwtToken = GetJwtToken(user);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return token;
    }

    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        return new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims:claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.Now.AddDays(_jwtSettings.ExpirationTimeInMinutes),
            signingCredentials: credentials);
    }

    public List<Claim> GetClaims(User user)
    {
        return new List<Claim>
        {
            new (ClaimTypes.Email, user.EmailAddress),
            new (ClaimConstants.UserId, user.Id.ToString())
        };
    }
}