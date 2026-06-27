using TrailStore.Basket.Contracts.Session;
using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Infrastructure.Sessions;

public static class ShoppingSessionExtensions
{
    public static ShoppingContext ToDomain(this ShoppingContextRef ctx)
        => new (ctx.OwnerId, ctx.SessionId is { } id ? Id<ShoppingSession>.From(id) : null);
}