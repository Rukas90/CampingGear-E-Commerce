using TrailStore.Ordering.Application.Results;
using TrailStore.Ordering.Domain.Orders;

namespace TrailStore.Ordering.Api.Endpoints.GetOrder;

public static class OrderSummaryResponseMapping
{
    public static OrderSummaryResponse ToResponse(OrderSummary summary)
        => new()
        {
            Subtotal = summary.Subtotal,
            Tax = summary.Tax,
            ShippingCost = summary.ShippingCost,
            ShippingName = summary.ShippingName,
            Total = summary.Total,
            LineItems = summary.LineItems.Select(ToLineResponse).ToArray()
        };

    private static OrderLineItemSummaryResponse ToLineResponse(OrderLineItem lineItem)
        => new()
        {
            ProductName = lineItem.ProductName,
            VariantLine = lineItem.VariantLine,
            UnitPrice = lineItem.UnitPrice,
            Quantity = lineItem.Quantity,
            ThumbnailUrl = lineItem.ThumbnailUrl
        };
}