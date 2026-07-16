using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Application.Mappings;
using TrailStore.Ordering.Application.Results;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.Queries.GetOrders;

[AppService<GetOrdersQueryHandler>]
public sealed class GetOrdersQueryHandler(IOrderRepository orderRepository)
    : IQueryHandler<GetOrdersQuery, OrderSummaryResult[]>
{
    public async Task<Result<OrderSummaryResult[]>> Handle(GetOrdersQuery query, CancellationToken ct)
    {
        if (query.UserId is null)
        {
            return Array.Empty<OrderSummaryResult>();
        }
        
        var orders = await orderRepository.GetUserOrdersAsync(query.UserId.Value, ct);

        if (orders.Length <= 0)
        {
            return Array.Empty<OrderSummaryResult>();
        }

        return orders.Select(order => order.ToSummary()).ToArray();
    }
}