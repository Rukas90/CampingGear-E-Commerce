using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Carts;

public sealed record CartSessionContext(Id<Cart>? CartId, Id<UserRef>? UserId);