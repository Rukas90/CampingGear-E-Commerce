using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Wishlist.Domain;

public sealed class CustomerWishlist : AggregateRoot<CustomerWishlist>
{
    public required Id<UserRef> UserId { get; init; }
    
    private readonly List<WishlistItem> _items = [];
    public IReadOnlyList<WishlistItem> Items =>  _items;

    public static CustomerWishlist Create(Id<UserRef> userId)
        => new()
        {
            Id = Id<CustomerWishlist>.New(),
            UserId = userId
        };
    
    public Result AddItem(Id<SkuRef> skuId)
    {
        if (IsSkuExist(skuId))
        {
            return WishlistProblems.ItemAlreadyAdded;
        }
        
        _items.Add(WishlistItem.Create(Id, skuId));
        
        return Result.Ok();
    }
    
    public Result RemoveItem(Id<SkuRef> skuId)
    {
        if (!IsSkuExist(skuId))
        {
            return WishlistProblems.ItemNotFound;
        }
        
        var index = _items.FindIndex(item => item.SkuId == skuId);
        
        _items.RemoveAt(index);
        
        return Result.Ok();
    }
    
    public Id<SkuRef>[] GetSkus()
        => _items.Select(item => item.SkuId).ToArray();
    
    private bool IsSkuExist(Id<SkuRef> id)
        => _items.Any(x => x.SkuId == id);
}