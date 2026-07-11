using Microsoft.AspNetCore.Http;
using TrailStore.Basket.Contracts.Carts;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Api.Extensions;

public static class SessionExtensions
{
    extension(HttpContext httpContext)
    {
        public CartSessionContextRef GetCartSessionContext()
            => new(httpContext.GetId<CartRef>(CartCookies.CartIdentifier), httpContext.User.GetId());

        public Id<CartRef>? GetCartId()
            => httpContext.GetId<CartRef>(CartCookies.CartIdentifier);
        
        public void ClearCartSessionCookieId()
            => httpContext.Response.Cookies.Delete(CartCookies.CartIdentifier);
    }
}