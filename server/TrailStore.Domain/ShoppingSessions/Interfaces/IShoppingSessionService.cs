using TrailStore.Domain.Shared.Models;
using TrailStore.Domain.ShoppingSessions.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.ShoppingSessions.Interfaces;

public interface IShoppingSessionService
{
    Task<ShoppingSession> GetOrCreateSession(ShoppingContext ctx, CancellationToken ct);
    
    Task<Result<ShoppingSession>> FindSession(ShoppingContext ctx, CancellationToken ct);

    Task<ShoppingSessionSummary> GetSessionSummary(ShoppingContext ctx, CancellationToken ct);

    Task ExtendSession(ShoppingSession session, CancellationToken ct);
}