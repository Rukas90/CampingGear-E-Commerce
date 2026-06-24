using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Api.Extensions;

namespace TrailStore.Basket.Api.Sessions;

public static class ContextExtensions
{
    extension(HttpContext httpContext)
    {
        public ShoppingContext GetShoppingContext(ClaimsPrincipal user)
            => new(user.GetUserId(), httpContext.GetShoppingSessionId());
    }
}