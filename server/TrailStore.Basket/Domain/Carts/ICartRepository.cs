using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Carts;

public interface ICartRepository : IAggregateRepository<Cart>
{
    Task<Cart?> FindByUserId(Id<UserRef> userId, CancellationToken ct);
}