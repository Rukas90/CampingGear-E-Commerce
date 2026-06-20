using Microsoft.AspNetCore.Http;
using TrailStore.Identity.Api.Api.Cookies;

namespace TrailStore.Identity.Api.Api.Extensions;

public static class RequestCookieExtensions
{
    extension(HttpRequest request)
    {
        public string? ToRefreshToken()
        {
            return request.Cookies[AuthCookies.RefreshToken];
        }
    }
}