namespace TrailStore.Api.Orders.Dto;

public sealed class OrderItemDto
{
    public required string SkuCode { get; init; }
    public required string ProductName { get; init; }
    public required string VariantLine { get; init; }
    public string? ImageUrl { get; init; }
    public required int Quantity { get; init; }
    public required decimal UnitPrice { get; init; }
}