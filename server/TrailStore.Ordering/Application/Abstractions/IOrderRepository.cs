using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Abstractions;

public interface IOrderRepository : IAggregateRepository<Order>
{
    Task<Order?> FindByTokenAsync(string token, CancellationToken ct);
    
    Task<Order[]> GetUserOrdersAsync(Id<UserRef> userId, CancellationToken ct);
}