using TrailStore.Domain.Carts.Models;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Orders.Interfaces;

public interface IOrderItemsService
{
    Task CreateOrderItems(Id<Order> orderId, CartLineItem[] entries, CancellationToken ct);
}