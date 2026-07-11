using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Contracts.Carts;

public sealed record CartSessionContextRef(Id<CartRef>? CartId, Id<UserRef>? UserId);