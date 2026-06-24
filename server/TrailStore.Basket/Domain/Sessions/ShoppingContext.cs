using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Sessions;

public record ShoppingContext(Guid? UserId, Id<ShoppingSession>? SessionId)
{
    public bool Invalid => UserId is null && SessionId is null;
}