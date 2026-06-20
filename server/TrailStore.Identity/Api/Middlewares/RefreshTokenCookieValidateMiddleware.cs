using Microsoft.AspNetCore.Http;
using TrailStore.Identity.Api.Api.Extensions;

namespace TrailStore.Identity.Api.Api.Middlewares;

public sealed class RefreshTokenCookieValidateMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.Equals("/api/v1/auth/refresh", StringComparison.OrdinalIgnoreCase))
        {
            var token = context.Request.ToRefreshToken();

            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                
                await context.Response.WriteAsync("Refresh token missing");
                
                return;
            }

            context.Items["RefreshToken"] = token;
        }

        await next(context);
    }
}