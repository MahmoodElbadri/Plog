using CodePlog.Api.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CodePlog.Api.Repositories;

public class TokenRepository(IConfiguration configuration) : ITokenRepository
{
    public string CreateJwtToken(IdentityUser user, List<string> roles)
    {
        var claims = new List<Claim>() { new Claim(ClaimTypes.Email, user.Email) };
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims: claims,
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            expires: DateTime.UtcNow.AddDays(300),
            signingCredentials: credentials);
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);

    }
}
