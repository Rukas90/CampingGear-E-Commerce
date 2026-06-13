namespace TrailStore.Domain.Orders.Models;

public class OrderItemSummary
{
    public required string SkuCode { get; init; }
    public required string ProductName { get; init; }
    public required string VariantLine { get; init; }
    public string? ImageUrl { get; init; }
    public required int Quantity { get; init; }
    public required decimal UnitPrice { get; init; }
}