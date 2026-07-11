using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Domain.Carts;

public class Cart : AggregateRoot<Cart>, IEntityCreatable, IEntityExpirable
{
    public Id<UserRef>? UserId { get; init; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }

    private readonly List<CartItem> _items = [];
    public IReadOnlyList<CartItem> Items => _items;

    public static Cart Create(Id<UserRef>? userId, TimeSpan expireTime)
        => new()
        {
            Id = Id<Cart>.New(),
            ExpiresAt = userId == null ? DateTime.UtcNow.Add(expireTime) : null,
            UserId = userId,
        };
    
    public Result AddItem(Id<SkuRef> skuId, int quantity)
    {
        var validation = Validate();

        if (!validation.IsSuccess)
        {
            return validation;
        }

        var existing = _items.FirstOrDefault(i => i.SkuId == skuId);

        if (existing != null)
        {
            existing.SetQuantity(existing.Quantity + quantity);
        }
        else
        {
            _items.Add(CartItem.Create(Id, skuId, quantity));
        }

        return Result.Ok();
    }
    
    public Result RemoveItem(Id<CartItem> itemId)
    {
        var validation = Validate();

        if (!validation.IsSuccess)
        {
            return validation;
        }
        
        var item = _items.FirstOrDefault(i => i.Id == itemId);

        if (item == null)
        {
            return CartProblems.ItemNotFound;
        }

        _items.Remove(item);
        
        return Result.Ok();
    }
    
    public Result UpdateItemQuantity(Id<CartItem> itemId, int quantity)
    {
        var validation = Validate();

        if (!validation.IsSuccess)
        {
            return validation;
        }
        
        var item = _items.FirstOrDefault(i => i.Id == itemId);

        if (item == null)
        {
            return CartProblems.ItemNotFound;
        }

        item.SetQuantity(quantity);

        return Result.Ok();
    }

    public Result Clear()
    {
        var validation = Validate();

        if (!validation.IsSuccess)
        {
            return validation;
        }
        
        _items.Clear();
        
        return Result.Ok();
    }

    public Result MergeWith(Cart cart)
    {
        if (Id == cart.Id)
        {
            return CartProblems.MergeWithSelf;
        }
        
        if (cart.UserId is not null)
        {
            return CartProblems.MergeWithUserCart;
        }

        if (UserId is null)
        {
            return CartProblems.MergeUserToAnonymous;
        }

        foreach (var otherCartItem in cart.Items)
        {
            AddItem(otherCartItem.SkuId, otherCartItem.Quantity);
        }
        
        cart.Clear();
        
        return Result.Ok();
    }
    
    public void Extend(TimeSpan duration)
    {
        if (IsExpired())
        {
            return;
        }
        
        ExpiresAt = DateTime.UtcNow.Add(duration);
    }
    
    private Result Validate()
    {
        if (IsExpired())
        {
            return CartProblems.Expired;
        }
        
        return Result.Ok();
    }
    
    public bool IsExpired() => UserId is null &&
        (this as IEntityExpirable).IsExpired;
}