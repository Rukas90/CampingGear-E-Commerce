using TrailStore.Ordering.Api.Common.PostalAddress;
using TrailStore.Ordering.Application.Results;
using TrailStore.Ordering.Domain.Orders;

namespace TrailStore.Ordering.Api.Orders;

public static class OrderSummaryResponseMapping
{
    public static OrderSummaryResponse ToResponse(this OrderSummary summary)
        => new()
        {
            EmailAddress = summary.EmailAddress,
            Token = summary.Token,
            Financials = new FinancialsResponse
            {
                Subtotal = summary.Subtotal,
                Tax = summary.Tax,
                ShippingCost = summary.ShippingCost,
                Total = summary.Total
            },
            ShippingName = summary.ShippingName,
            LineItems = summary.LineItems.Select(ToLineResponse).ToArray(),
            Billing = summary.BillingAddress.ToResponse()
        };

    private static OrderLineItemSummaryResponse ToLineResponse(OrderLineItem lineItem)
        => new()
        {
            BrandName = lineItem.BrandName,
            ProductName = lineItem.ProductName,
            VariantLine = lineItem.VariantLine,
            UnitPrice = lineItem.UnitPrice,
            Quantity = lineItem.Quantity,
            ThumbnailUrl = lineItem.ThumbnailUrl
        };
}