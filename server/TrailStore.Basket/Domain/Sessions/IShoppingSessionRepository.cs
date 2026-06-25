using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Sessions;

public interface IShoppingSessionRepository : IAggregateRepository<ShoppingSession>
{
    Task<ShoppingSession?> FindByUserId(Id<UserRef> userId, CancellationToken ct);
}