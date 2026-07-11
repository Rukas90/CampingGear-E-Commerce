using TrailStore.Basket.Domain.Sessions;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Application.Abstractions;

public interface IShoppingSessionService
{
    Task<ShoppingSession> FindOrCreateSession(ShoppingContext ctx, CancellationToken ct);
    
    Task<Result<ShoppingSession>> FindSession(ShoppingContext ctx, CancellationToken ct);
    
    Task<ShoppingSession> FindOrCreateUserSession(Id<UserRef> userId, CancellationToken ct);
}