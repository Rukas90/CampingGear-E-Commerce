using TrailStore.Basket.Domain.Sessions;
using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Carts;

public class CartItem : IModel<CartItem>, IEntityCreatable
{
    public Id<CartItem> Id { get; init; }
    public Id<ShoppingSession> SessionId { get; init; }
    public Id<SkuRef> SkuId { get; init; }
    public int Quantity { get; private set; }

    public DateTime CreatedAt { get; set; }

    public ShoppingSession ShoppingSession { get; private set; } = null!;

    public static CartItem Create(
        Id<ShoppingSession> sessionId, Id<SkuRef> skuId, int quantity)
        => new()
        {
            Id = Id<CartItem>.New(),
            SessionId = sessionId,
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