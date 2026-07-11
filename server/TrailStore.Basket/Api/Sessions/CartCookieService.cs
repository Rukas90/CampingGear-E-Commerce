using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Basket.Infrastructure.Carts;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Api.Sessions;

[AppService<CartCookieService>]
public sealed class CartCookieService(
    IHttpContextAccessor httpContextAccessor,
    IOptions<CartOptions> options)
{
    private readonly CookieOptions cookieOptions = new()
    {
        MaxAge = TimeSpan.FromMinutes(options.Value.ExpiryMinutes),
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        Secure = true,
    };
    
    private HttpContext Http => httpContextAccessor.HttpContext!;
    
    public void SyncCart(Id<Cart> next)
    {
        if (!next.Equals(Http.GetCartId()))
        {
            UpdateCartId(next);
        }
    }
    
    public void UpdateCartId(Id<Cart> cartId)
    {
        Http.Response.Cookies.Append(
            CartCookies.CartIdentifier,
            cartId.ToString(),
            cookieOptions);
    }

    public void ClearCartId()
    {
        Http.Response.Cookies.Delete(CartCookies.CartIdentifier);
    }
}