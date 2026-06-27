using Microsoft.AspNetCore.Http;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Shared.Api.Extensions;

public static class CookieExtensions
{
    extension(HttpContext httpContext)
    {
        public Id<T>? GetId<T>(string cookieIdentifier)
        {
            httpContext.Request.Cookies.TryGetValue(cookieIdentifier, out var strId);

            if (strId is null || !Guid.TryParse(strId, out var guid))
            {
                return null;
            }
            
            return Id<T>.From(guid);
        }
        
        public void DeleteCookie(string cookieIdentifier)
        {
            httpContext.Response.Cookies.Delete(cookieIdentifier);
        }
    }
}