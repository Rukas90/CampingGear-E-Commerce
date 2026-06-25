using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Sessions;

public sealed record ShoppingContext(Id<UserRef>? UserId, Id<ShoppingSession>? SessionId)
{
    public bool Invalid => UserId is null && SessionId is null;
}