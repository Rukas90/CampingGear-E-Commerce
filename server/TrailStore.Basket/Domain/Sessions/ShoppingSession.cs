using TrailStore.Basket.Domain.Carts;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Sessions;

public class ShoppingSession : AggregateRoot<ShoppingSession>, IEntityCreatable, IEntityExpirable
{
    public Guid? UserId { get; init; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }

    private readonly List<CartItem> _cartItems = [];
    public IReadOnlyList<CartItem> CartItems => _cartItems;

    public static ShoppingSession Create(Guid? userId, TimeSpan expireTime)
        => new()
        {
            Id = Id<ShoppingSession>.New(),
            ExpiresAt = userId == null ? DateTime.UtcNow.Add(expireTime) : null,
            UserId = userId,
        };
    
    public void AddCartItem(Guid skuId, int quantity)
    {
        ValidateSession();

        var existing = _cartItems.FirstOrDefault(i => i.SkuId == skuId);

        if (existing != null)
        {
            existing.SetQuantity(existing.Quantity + quantity);
        }
        else
        {
            _cartItems.Add(CartItem.Create(Id, skuId, quantity));
        }
    }
    
    public Result RemoveCartItem(Id<CartItem> itemId)
    {
        ValidateSession();
        
        var item = _cartItems.FirstOrDefault(i => i.Id == itemId);

        if (item == null)
        {
            return CartProblems.ItemNotFound;
        }

        _cartItems.Remove(item);
        
        return Result.Ok();
    }
    
    public Result UpdateCartItemQuantity(Id<CartItem> itemId, int quantity)
    {
        ValidateSession();
        
        var item = _cartItems.FirstOrDefault(i => i.Id == itemId);

        if (item == null)
        {
            return CartProblems.ItemNotFound;
        }

        item.SetQuantity(quantity);

        return Result.Ok();
    }

    public void ClearCart()
    {
        ValidateSession();
        
        _cartItems.Clear();
    }
    
    public void Extend(TimeSpan duration)
    {
        if (UserId != null || IsExpired())
        {
            return;
        }
        
        ExpiresAt = DateTime.UtcNow.Add(duration);
    }
    
    private void ValidateSession()
    {
        if (IsExpired())
        {
            throw new InvalidOperationException("Session has expired.");
        }
    }
    
    public bool IsExpired() =>
        (this as IEntityExpirable).IsExpired;
}