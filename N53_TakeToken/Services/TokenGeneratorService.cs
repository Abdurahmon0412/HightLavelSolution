﻿using Microsoft.IdentityModel.Tokens;
using N53_TakeToken.Constants;
using N53_TakeToken.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace N53_TakeToken.Services;

public class TokenGeneratorService
{
    public string SecretKey = "8E6225FC-6E84-4E50-805F-FB3B5B6138BE";

    public string GetToken(User user)
    {
        var jwtToken = GetJwtToken(user);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return token;
    }

    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        return new JwtSecurityToken(issuer:"dsdfadfqsa",
            audience:"wdqfweqe",
            claims:claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.Now.AddDays(1),
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
