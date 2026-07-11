using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Extensions;

namespace TrailStore.Identity.Api.Extensions;

public static class SessionExtensions
{
    extension(HttpContext httpContext)
    {
        public ShoppingContextRef GetShoppingContext(ClaimsPrincipal user)
            => new(user.GetUserId(), httpContext.GetId<ShoppingSessionRef>(SessionCookies.ShoppingSessionIdentifier));
        
        public void ClearShoppingContext()
            => httpContext.Response.Cookies.Delete(SessionCookies.ShoppingSessionIdentifier);
    }
}