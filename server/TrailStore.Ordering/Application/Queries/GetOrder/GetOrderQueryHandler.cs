using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Application.Results;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.Queries.GetOrder;

[AppService<GetOrderQueryHandler>]
public sealed class GetOrderQueryHandler(IOrderRepository orderRepository)
    : IQueryHandler<GetOrderQuery, OrderSummary>
{
    public async Task<Result<OrderSummary>> Handle(GetOrderQuery query, CancellationToken ct)
    {
        var order = await orderRepository.FindReadOnlyAsync(query.OrderId, ct);

        if (order is null)
        {
            return OrderProblems.NotFound(query.OrderId);
        }

        return new OrderSummary
        {
            Subtotal = order.Subtotal,
            Tax = order.TaxAmount,
            ShippingCost = order.Shipping.PriceBeforeTax,
            ShippingName = order.Shipping.MethodName,
            Total = order.TotalPrice,
            LineItems = order.Items.Select(item => item.ToLineItem()).ToArray()
        };
    }
}