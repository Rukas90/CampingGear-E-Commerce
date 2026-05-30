using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Common.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Id<Customer>? GetCustomerId(this ClaimsPrincipal claims)
    {
        var idValue = claims.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        
        return idValue is null ? null : Id<Customer>.From(idValue);
    }
}