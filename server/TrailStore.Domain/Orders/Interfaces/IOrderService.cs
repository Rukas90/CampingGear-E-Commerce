using TrailStore.Domain.Orders.Requests;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Orders.Interfaces;

public interface IOrderService
{
    Task<Result<Order>> CreateOrder(CreateOrderRequest request, CancellationToken ct);
}