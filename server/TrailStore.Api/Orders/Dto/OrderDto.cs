namespace TrailStore.Api.Orders.Dto;

public class OrderDto
{
    public required string Token { get; init; }
    public required decimal Subtotal { get; init; }
    public required decimal TaxAmount { get; init; }
    public required decimal TotalPrice { get; init; }
    public required IEnumerable<OrderItemDto> Items { get; init; } = [];
}