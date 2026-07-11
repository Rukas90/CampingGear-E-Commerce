using Microsoft.AspNetCore.Http;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Identity.Contracts.Users;

namespace TrailStore.Basket.Api.Extensions;

public static class ContextExtensions
{
    extension(HttpContext httpContext)
    {
        public CartSessionContext GetCartSessionContext()
            => new(httpContext.GetCartId(), httpContext.User.GetId());
    }
}