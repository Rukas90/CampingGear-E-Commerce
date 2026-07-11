using System.Security.Claims;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Contracts.Users;

public static class ClaimsPrincipalExtensions
{
    public static Id<UserRef>? GetId(this ClaimsPrincipal claims)
    {
        var idValue = claims.FindFirst(IdentityClaimNames.Subject)?.Value;

        if (!string.IsNullOrEmpty(idValue) && Guid.TryParse(idValue, out var id))
        {
            return Id<UserRef>.From(id);
        }

        return null;
    }
}