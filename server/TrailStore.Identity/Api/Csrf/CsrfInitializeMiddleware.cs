using Microsoft.AspNetCore.Http;
using TrailStore.Identity.Api.Cookies;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Api.Csrf;

[AppService<CsrfInitializeMiddleware>]
public class CsrfInitializeMiddleware(IAuthCookieService cookieService) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.Request.Cookies.ContainsKey(CsrfConstants.CookieName))
        {
            cookieService.SetCsrfToken(context.Response);
        }

        await next(context);
    }
}