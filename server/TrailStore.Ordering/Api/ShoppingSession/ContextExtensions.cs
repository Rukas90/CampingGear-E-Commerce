using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Extensions;

namespace TrailStore.Ordering.Api.ShoppingSession;

public static class ContextExtensions
{
    extension(HttpContext httpContext)
    {
        public ShoppingContextRef GetShoppingContext(ClaimsPrincipal user)
            => new(user.GetUserId(), httpContext.GetId<ShoppingSessionRef>(SessionCookies.ShoppingSessionIdentifier));
    }
}