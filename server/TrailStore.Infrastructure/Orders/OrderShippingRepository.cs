using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Orders.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Orders;

[AppService<IOrderShippingRepository>]
public class OrderShippingRepository(AppDbContext context) : IOrderShippingRepository
{
    public OrderShipping Add(OrderShipping shipping)
    {
        context.OrderShippings.Add(shipping);

        return shipping;
    }

    public Task<OrderShipping?> FindByOrderIdAsync(Id<Order> orderId, CancellationToken ct)
        => context.OrderShippings.FirstOrDefaultAsync(shipping => shipping.OrderId == orderId, ct);
}