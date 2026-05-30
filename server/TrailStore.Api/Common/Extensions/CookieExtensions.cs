using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;
using TrailStore.Shared.Cookies;

namespace TrailStore.Api.Common.Extensions;

public static class CookieExtensions
{
    extension(HttpContext httpContext)
    {
        public Id<ShoppingSession>? GetShoppingSessionId()
        {
            httpContext.Request.Cookies.TryGetValue(SessionCookies.ShoppingSessionIdentifier, out var sessionId);

            if (sessionId is null || !Guid.TryParse(sessionId, out var guid))
            {
                return null;
            }
            
            return Id<ShoppingSession>.From(guid);
        }
        
        public void ClearShoppingSessionId()
        {
            httpContext.Response.Cookies.Delete(SessionCookies.ShoppingSessionIdentifier);
        }
    }
}