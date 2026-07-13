using Microsoft.AspNetCore.Http;
using TrailStore.Identity.Api.Cookies;

namespace TrailStore.Identity.Api.Extensions;

public static class RequestCookieExtensions
{
    extension(HttpRequest request)
    {
        public string? ToJti()
            => request.Cookies[AuthCookies.AccessToken];
        
        public string? ToRefreshToken()
            => request.Cookies[AuthCookies.RefreshToken];
    }
}