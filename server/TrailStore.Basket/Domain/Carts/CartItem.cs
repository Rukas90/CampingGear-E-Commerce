using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Carts;

public class CartItem : IModel<CartItem>, IEntityCreatable
{
    public Id<CartItem> Id { get; init; }
    public Id<Cart> CartId { get; init; }
    public Id<SkuRef> SkuId { get; init; }
    public int Quantity { get; private set; }

    public DateTime CreatedAt { get; set; }

    public Cart Cart { get; private set; } = null!;

    public static CartItem Create(
        Id<Cart> cartId, Id<SkuRef> skuId, int quantity)
        => new()
        {
            Id = Id<CartItem>.New(),
            CartId = cartId,
            SkuId = skuId,
            Quantity = quantity
        };
    
    public void SetQuantity(int quantity)
    {
        if (quantity < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be at least 1.");
        }
        
        Quantity = quantity;
    }
}