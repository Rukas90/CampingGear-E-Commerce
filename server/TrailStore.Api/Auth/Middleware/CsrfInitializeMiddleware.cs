using TrailStore.Api.Auth.Constants;
using TrailStore.Api.Auth.Cookies;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Auth.Middleware;

[AppService<CsrfInitializeMiddleware>]
public class CsrfInitializeMiddleware(IAuthCookieService cookieService) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.Request.Cookies.ContainsKey(CsrfConstants.CookieName))
            cookieService.SetCsrfToken(context.Response);

        await next(context);
    }
}