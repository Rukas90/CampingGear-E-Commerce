namespace TrailStore.Ordering.Api.Orders;

public class OrderLineItemSummaryResponse
{
    public required string BrandName { get; init; }
    public required string ProductName { get; init; }
    public required string VariantLine { get; init; }
    public required decimal UnitPrice { get; init; }
    public required int Quantity { get; init; }
    public string? ThumbnailUrl { get; init; }
}