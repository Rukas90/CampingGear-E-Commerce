using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Basket.Domain.Sessions;

public interface IShoppingSessionRepository : IAggregateRepository<ShoppingSession>
{
    Task<ShoppingSession?> FindByUserId(Guid userId, CancellationToken ct);
}