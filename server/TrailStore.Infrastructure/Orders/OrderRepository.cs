using TrailStore.Domain.Orders.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Orders;

[AppService<IOrderRepository>]
public class OrderRepository(AppDbContext context) : IOrderRepository
{
    public Order Add(Order order)
    {
        context.Orders.Add(order);

        return order;
    }
}