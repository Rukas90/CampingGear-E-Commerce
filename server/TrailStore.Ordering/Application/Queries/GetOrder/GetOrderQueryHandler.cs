using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Application.Results;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Ordering.Infrastructure.Orders;
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
        if (!OrderTokenization.TryNormalizeToken(query.Token, out var token))
        {
            return OrderProblems.NotFound(query.Token);
        }
        
        var order = await orderRepository.FindByTokenAsync(token, ct);

        if (order is null)
        {
            return OrderProblems.NotFound(token);
        }

        return new OrderSummary
        {
            Token = OrderTokenization.ToDisplayToken(token),
            Subtotal = order.Subtotal,
            Tax = order.TaxAmount,
            ShippingCost = order.Shipping.PriceBeforeTax,
            ShippingName = order.Shipping.MethodName,
            Total = order.TotalPrice,
            LineItems = order.Items.Select(item => item.ToLineItem()).ToArray()
        };
    }
}