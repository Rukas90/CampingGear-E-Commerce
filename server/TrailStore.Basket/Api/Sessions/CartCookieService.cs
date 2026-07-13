using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Basket.Infrastructure.Carts;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Basket.Api.Sessions;

[AppService<ICartCookieService>]
public sealed class CartCookieService(
    IHttpContextAccessor httpContextAccessor,
    IOptions<CartOptions> options) : ICartCookieService
{
    private readonly CookieOptions cookieOptions = new()
    {
        MaxAge = TimeSpan.FromMinutes(options.Value.ExpiryMinutes),
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        Secure = true,
    };
    
    private HttpContext Http => httpContextAccessor.HttpContext!;
    
    public void SyncCart(Guid next)
    {
        if (!next.Equals(GetId()))
        {
            UpdateCart(next);
        }
    }
    
    public void UpdateCart(Guid? id)
    {
        if (id is null)
        {
            ClearCart();
            
            return;
        }
        Http.Response.Cookies.Append(
            CartCookies.CartIdentifier,
            id.Value.ToString(),
            cookieOptions);
    }

    public Guid? GetId()
    {
        if (Http.Request.Cookies.TryGetValue(CartCookies.CartIdentifier, out var idStr)
            && Guid.TryParse(idStr, out var cartId))
        {
            return cartId;
        }
        
        return null;
    }
    
    public void ClearCart()
    {
        Http.Response.Cookies.Delete(CartCookies.CartIdentifier);
    }
}