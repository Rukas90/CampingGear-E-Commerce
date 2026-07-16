using TrailStore.Ordering.Api.Common.PostalAddress;
using TrailStore.Ordering.Application.Results;
using TrailStore.Ordering.Domain.Orders;

namespace TrailStore.Ordering.Api.Orders;

public static class OrderResponseMapping
{
    public static OrderSummaryResponse[] ToResponses(this IEnumerable<OrderSummaryResult> summaries)
        => summaries.Select(ToResponse).ToArray();
    
    public static OrderSummaryResponse ToResponse(this OrderSummaryResult summary)
        => new()
        {
            Id = summary.Id,
            Token = summary.Token,
            CreatedAt = summary.CreatedAt,
            Status = summary.Status,
            Total = summary.Total
        };
    
    public static OrderDetailsResponse ToResponse(this OrderDetailsResult details)
        => new()
        {
            EmailAddress = details.EmailAddress,
            Token = details.Token,
            Financials = new FinancialsResponse
            {
                Subtotal = details.Subtotal,
                Tax = details.Tax,
                ShippingCost = details.ShippingCost,
                Total = details.Total
            },
            ShippingName = details.ShippingName,
            Status = details.Status,
            CreatedAt = details.CreatedAt,
            LineItems = details.LineItems.Select(ToLineResponse).ToArray(),
            Billing = details.BillingAddress.ToResponse()
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