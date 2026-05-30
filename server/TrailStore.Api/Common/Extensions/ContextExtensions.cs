using System.Security.Claims;
using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.ShoppingSessions.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Common.Extensions;

public static class ContextExtensions
{
    extension(HttpContext httpContext)
    {
        public ShoppingContext GetShoppingContext(ClaimsPrincipal user)
            => new(user.GetCustomerId(), httpContext.GetShoppingSessionId());
    }
}