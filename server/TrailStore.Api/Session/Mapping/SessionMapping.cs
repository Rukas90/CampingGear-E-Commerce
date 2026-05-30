using TrailStore.Api.Session.Dto;
using TrailStore.Domain.ShoppingSessions.Models;

namespace TrailStore.Api.Session.Mapping;

public static class SessionMapping
{
    public static SessionSummaryDto ToDto(this ShoppingSessionSummary summary)
        => new()
        {
            CartCount = summary.CartCount,
            WishlistCount = summary.WishlistCount
        };
}