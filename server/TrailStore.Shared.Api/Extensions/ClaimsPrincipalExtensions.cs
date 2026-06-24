using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TrailStore.Shared.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid? GetUserId(this ClaimsPrincipal claims)
    {
        var idValue = claims.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

        if (!string.IsNullOrEmpty(idValue) && Guid.TryParse(idValue, out var id))
        {
            return id;
        }

        return null;
    }
}