using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Sessions;

public sealed record ShoppingContext(Id<UserRef>? OwnerId, Id<ShoppingSession>? SessionId) 
    : SessionContext<UserRef,ShoppingSession>(OwnerId, SessionId);