using Microsoft.AspNetCore.Http;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Api.Extensions;

public static class ContextExtensions
{
    extension(HttpContext httpContext)
    {
        public CartSessionContext GetCartSessionContext()
            => new(httpContext.GetCartId(), Id<UserRef>.FromNullable(httpContext.User.GetSubjectId()));
    }
}