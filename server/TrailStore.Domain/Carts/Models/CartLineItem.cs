namespace TrailStore.Domain.Carts.Models;

public class CartLineItem
{
    public required string Code { get; init; }
    public required int Quantity { get; init; }
}