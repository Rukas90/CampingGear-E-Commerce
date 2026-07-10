using TrailStore.Ordering.Application.Results;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Ordering.Infrastructure.Orders;

namespace TrailStore.Ordering.Application.Mappings;

public static class OrderMappingExtensions
{
    extension(Order order)
    {
        public OrderSummary ToSummary()
            => new()
            {
                EmailAddress = order.EmailAddress,
                Token = OrderTokenization.ToDisplayToken(order.Token),
                Subtotal = order.Subtotal,
                Tax = order.TaxAmount,
                ShippingCost = order.Shipping.PriceBeforeTax,
                ShippingName = order.Shipping.MethodName,
                Total = order.TotalPrice,
                LineItems = order.Items.Select(item => item.ToLineItem()).ToArray(),
                BillingAddress = order.BillingAddress,
            };
    }
}