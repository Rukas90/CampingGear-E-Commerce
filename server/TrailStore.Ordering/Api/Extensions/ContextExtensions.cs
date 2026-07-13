using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TrailStore.Basket.Contracts.Carts;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Api.Extensions;

public static class ContextExtensions
{
    extension(HttpContext httpContext)
    {
        public CartSessionContextRef GetCartSessionContext(ClaimsPrincipal user)
            => new(httpContext.GetId<CartRef>(CartCookies.CartIdentifier), Id<UserRef>.FromNullable(user.GetSubjectId()));

        public Id<CartRef>? GetCartId()
            => httpContext.GetId<CartRef>(CartCookies.CartIdentifier);
    }
}