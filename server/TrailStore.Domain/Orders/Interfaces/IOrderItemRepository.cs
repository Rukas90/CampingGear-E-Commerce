using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Orders.Interfaces;

public interface IOrderItemRepository
{
    void AddRange(IEnumerable<OrderItem> items);
}