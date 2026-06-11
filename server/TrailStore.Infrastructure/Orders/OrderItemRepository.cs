using TrailStore.Domain.Orders.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Orders;

[AppService<IOrderItemRepository>]
public class OrderItemRepository(AppDbContext context) : IOrderItemRepository
{
    public void AddRange(IEnumerable<OrderItem> items)
    {
        context.OrderItems.AddRange(items);
    }
}