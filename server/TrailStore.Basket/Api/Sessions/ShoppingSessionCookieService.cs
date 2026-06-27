using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Basket.Infrastructure.Sessions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Api.Sessions;

[AppService<ShoppingSessionCookieService>]
public sealed class ShoppingSessionCookieService(
    IHttpContextAccessor httpContextAccessor,
    IOptions<ShoppingSessionOptions> options)
{
    private readonly CookieOptions cookieOptions = new()
    {
        MaxAge = TimeSpan.FromMinutes(options.Value.ExpiryMinutes),
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        Secure = true,
    };
    
    private HttpContext Http => httpContextAccessor.HttpContext!;
    
    public void SyncShoppingSession(
        Id<ShoppingSession>? current, Id<ShoppingSession> next)
    {
        if (!next.Equals(current))
        {
            UpdateShoppingSessionId(next);
        }
    }
    
    public void UpdateShoppingSessionId(Id<ShoppingSession> sessionId)
    {
        Http.Response.Cookies.Append(
            SessionCookies.ShoppingSessionIdentifier,
            sessionId.ToString(),
            cookieOptions);
    }
}