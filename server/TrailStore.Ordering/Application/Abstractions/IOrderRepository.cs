using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Ordering.Application.Abstractions;

public interface IOrderRepository : IAggregateRepository<Order>;