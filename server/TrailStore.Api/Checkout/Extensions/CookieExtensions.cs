using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;
using TrailStore.Shared.Cookies;

namespace TrailStore.Api.Checkout.Extensions;

public static class CookieExtensions
{
    extension(HttpContext context)
    {
        public Id<CheckoutSession>? GetCheckoutSessionId()
        {
            if (context.Request.Cookies.TryGetValue(SessionCookies.CheckoutSessionIdentifier, out var str) 
                && Guid.TryParse(str, out var guid))
            {
                return Id<CheckoutSession>.From(guid);
            }
            
            return null;
        }
    }
}