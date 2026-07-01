using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Ordering.Domain.Orders;

public interface IOrderRepository : IAggregateRepository<Order>;