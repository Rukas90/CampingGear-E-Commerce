using TrailStore.Basket.Domain.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Sessions;

public sealed record ShoppingContext(Id<UserRef>? OwnerId, Id<Cart>? SessionId) 
    : SessionContext<UserRef, Cart>(OwnerId, SessionId);