using TrailStore.Basket.Domain.Carts;
using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Sessions;

public class ShoppingSession : AggregateRoot<ShoppingSession>, IEntityCreatable, IEntityExpirable
{
    public Id<UserRef>? UserId { get; init; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }

    private readonly List<CartItem> _cartItems = [];
    public IReadOnlyList<CartItem> CartItems => _cartItems;

    public static ShoppingSession Create(Id<UserRef>? userId, TimeSpan expireTime)
        => new()
        {
            Id = Id<ShoppingSession>.New(),
            ExpiresAt = userId == null ? DateTime.UtcNow.Add(expireTime) : null,
            UserId = userId,
        };
    
    public Result AddCartItem(Id<SkuRef> skuId, int quantity)
    {
        var validation = ValidateSession();

        if (!validation.IsSuccess)
        {
            return validation;
        }

        var existing = _cartItems.FirstOrDefault(i => i.SkuId == skuId);

        if (existing != null)
        {
            existing.SetQuantity(existing.Quantity + quantity);
        }
        else
        {
            _cartItems.Add(CartItem.Create(Id, skuId, quantity));
        }

        return Result.Ok();
    }
    
    public Result RemoveCartItem(Id<CartItem> itemId)
    {
        var validation = ValidateSession();

        if (!validation.IsSuccess)
        {
            return validation;
        }
        
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
        var validation = ValidateSession();

        if (!validation.IsSuccess)
        {
            return validation;
        }
        
        var item = _cartItems.FirstOrDefault(i => i.Id == itemId);

        if (item == null)
        {
            return CartProblems.ItemNotFound;
        }

        item.SetQuantity(quantity);

        return Result.Ok();
    }

    public Result ClearCart()
    {
        var validation = ValidateSession();

        if (!validation.IsSuccess)
        {
            return validation;
        }
        
        _cartItems.Clear();
        
        return Result.Ok();
    }

    public Result MergeWith(ShoppingSession shoppingSession)
    {
        if (Id == shoppingSession.Id)
        {
            return ShoppingSessionsProblems.MergeWithSelf;
        }
        
        if (shoppingSession.UserId is not null)
        {
            return ShoppingSessionsProblems.MergeWithUserSession;
        }

        if (UserId is null)
        {
            return ShoppingSessionsProblems.MergeWithAnonymous;
        }

        MergeCartItems(shoppingSession);
        
        return Result.Ok();
    }

    private void MergeCartItems(ShoppingSession shoppingSession)
    {
        foreach (var otherCartItem in shoppingSession.CartItems)
        {
            AddCartItem(otherCartItem.SkuId, otherCartItem.Quantity);
        }
        
        shoppingSession.ClearCart();
    }
    
    public void Extend(TimeSpan duration)
    {
        if (IsExpired())
        {
            return;
        }
        
        ExpiresAt = DateTime.UtcNow.Add(duration);
    }
    
    private Result ValidateSession()
    {
        if (IsExpired())
        {
            return ShoppingSessionsProblems.SessionExpired;
        }
        
        return Result.Ok();
    }
    
    public bool IsExpired() => UserId is null &&
        (this as IEntityExpirable).IsExpired;
}