using Microsoft.AspNetCore.Http;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Api.Sessions;

public static class ContextExtensions
{
    extension(HttpContext httpContext)
    {
        public Id<Cart>? GetCartId()
            => httpContext.GetId<Cart>(CartCookies.CartIdentifier);
    }
}