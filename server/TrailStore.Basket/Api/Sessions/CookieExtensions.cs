using Microsoft.AspNetCore.Http;
using TrailStore.Basket.Api.Constants;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Api.Sessions;

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