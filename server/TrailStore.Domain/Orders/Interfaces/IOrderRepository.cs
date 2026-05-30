using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Orders.Interfaces;

public interface IOrderRepository
{
    Task<Order> CreateAsync(Order order, CancellationToken ct);
}