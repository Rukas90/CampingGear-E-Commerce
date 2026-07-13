using System.Security.Claims;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Shared.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    extension(ClaimsPrincipal principal)
    {
        public Id<T>? GetSubjectTypedId<T>()
        {
            var value = principal.FindFirstValue(ClaimNames.Subject);

            if (value is null || !Guid.TryParse(value, out var id))
            {
                return null;
            }

            return Id<T>.FromNullable(id);
        }
        
        public Guid? GetSubjectId()
        {
            var value = principal.FindFirstValue(ClaimNames.Subject);

            if (value is null || !Guid.TryParse(value, out var id))
            {
                return null;
            }

            return id;
        }

        public bool TryGetSubjectId(out Guid? id)
        {
            var value = principal.FindFirstValue(ClaimNames.Subject);
            
            if (value is null || !Guid.TryParse(value, out var parsed))
            {
                id = null;
                
                return false;
            }

            id = parsed;
            
            return true;
        }

        public string? GetEmail() =>
            principal.FindFirstValue(ClaimNames.Email);

        public DateTimeOffset? GetExpiration()
        {
            var value = principal.FindFirstValue(ClaimNames.Expiration);

            if (value is null || !long.TryParse(value, out var seconds))
            {
                return null;
            }

            return DateTimeOffset.FromUnixTimeSeconds(seconds);
        }
    }
}