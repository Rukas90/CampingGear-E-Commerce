using System.Linq.Expressions;
using TrailStore.Domain.Orders.Requests;
using TrailStore.Domain.Orders.Results;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Orders.Interfaces;

public interface IOrderService
{
    Task<Result<TResult>> GetOrder<TResult>(string token, Expression<Func<Order, TResult>> selector, CancellationToken ct);
    Task<Result<CreateOrderResult>> CreateOrder(CreateOrderRequest request, CancellationToken ct);
}