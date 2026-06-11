using TrailStore.Domain.Shared.Interfaces;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class CartItem : IModel<CartItem>, IEntityCreatable
{
    public Id<CartItem> Id { get; init; }
    public Id<ShoppingSession> SessionId { get; init; }
    public Id<Sku> SkuId { get; init; }
    public int Quantity { get; private set; }

    public DateTime CreatedAt { get; set; }

    public ShoppingSession ShoppingSession { get; private set; } = null!;
    public Sku Sku { get; private set; } = null!;

    public static CartItem Create(
        Id<ShoppingSession> sessionId, Id<Sku> skuId, int quantity)
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