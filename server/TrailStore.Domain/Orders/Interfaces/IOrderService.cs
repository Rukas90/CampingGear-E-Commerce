using TrailStore.Domain.Orders.Models;
using TrailStore.Domain.Orders.Requests;
using TrailStore.Domain.Orders.Results;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Orders.Interfaces;

public interface IOrderService
{
    Task<Result<OrderSummary>> GetOrderSummary(string token, CancellationToken ct);
    Task<Result<CreateOrderResult>> CreateOrder(CreateOrderRequest request, CancellationToken ct);
}