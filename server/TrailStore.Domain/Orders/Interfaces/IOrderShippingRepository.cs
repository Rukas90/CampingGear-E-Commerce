using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Orders.Interfaces;

public interface IOrderShippingRepository
{
    OrderShipping Add(OrderShipping shipping);
    
    Task<OrderShipping?> FindByOrderIdAsync(Id<Order> orderId, CancellationToken ct);
}