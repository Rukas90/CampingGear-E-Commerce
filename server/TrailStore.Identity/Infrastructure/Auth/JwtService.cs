using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TrailStore.Identity.Application.Abstractions;
using TrailStore.Identity.Domain.Users;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Infrastructure.Auth;

[AppService<IJwtService>]
internal sealed class JwtService(IOptions<JwtOptions> options) : IJwtService
{
    private readonly JwtOptions jwtOptions = options.Value;
    
    public string GenerateAccessToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            jwtOptions.Issuer,
            jwtOptions.Audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(jwtOptions.AccessTokenExpiryMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}