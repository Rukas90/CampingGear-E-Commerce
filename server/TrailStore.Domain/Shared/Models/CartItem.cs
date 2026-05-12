using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class CartItem : IModel<CartItem>
{
    public Id<Cart> CartId { get; init; }
    public Id<Sku> SkuId { get; init; }
    public DateTime AddedAt { get; init; }
    public int Quantity { get; set; }

    public Cart Cart { get; private set; } = null!;
    public Sku Sku { get; private set; } = null!;
    public Id<CartItem> Id { get; init; }
}