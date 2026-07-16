using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Application.Mappings;
using TrailStore.Ordering.Application.Results;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.Queries.GetOrder;

[AppService<GetOrderQueryHandler>]
public sealed class GetOrderQueryHandler(IOrderRepository orderRepository)
    : IQueryHandler<GetOrderQuery, OrderDetailsResult>
{
    public async Task<Result<OrderDetailsResult>> Handle(GetOrderQuery query, CancellationToken ct)
    {
        var order = await orderRepository.FindAsync(query.Id, ct);

        if (order is null)
        {
            return OrderProblems.NotFound(query.Id);
        }

        return order.ToDetails();
    }
}