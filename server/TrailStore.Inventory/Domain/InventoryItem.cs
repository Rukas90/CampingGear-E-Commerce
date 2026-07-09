using TrailStore.Shared.Domain.Common;

namespace TrailStore.Inventory.Domain;

public sealed class InventoryItem : AggregateRoot<InventoryItem>
{
    public required Guid SkuId { get; init; }
    public required int Stock { get; set; }
    public required int Reserved { get; set; }
    
    public int AvailableStock => Stock - Reserved;

    public static InventoryItem Create(Guid skuId, int stock, int reserved)
        => new()
        {
            Id = Id<InventoryItem>.New(),
            SkuId = skuId,
            Stock = stock,
            Reserved = reserved
        };
    
    public Result Reserve(int quantity)
    {
        if (quantity <= 0)
        {
            return InventoryProblems.InvalidQuantity(quantity);
        }
        
        if (AvailableStock < quantity)
        {
            return InventoryProblems.InsufficientStock(SkuId, quantity, AvailableStock);
        }
        
        Reserved += quantity;
        
        RaiseDomainEvent(new StockReservedDomainEvent(SkuId, AvailableStock));
        
        return Result.Ok();
    }

    public Result Revert(int quantity)
    {
        if (quantity <= 0)
        {
            return InventoryProblems.InvalidQuantity(quantity);
        }
        
        if (Reserved < quantity)
        {
            return InventoryProblems.InsufficientStock(SkuId, quantity, Reserved);
        }
        
        Reserved -= quantity;
        
        RaiseDomainEvent(new StockReservedDomainEvent(SkuId, AvailableStock));
        
        return Result.Ok();
    }

    public Result Confirm(int quantity)
    {
        if (quantity <= 0)
        {
            return InventoryProblems.InvalidQuantity(quantity);
        }
        
        Reserved -= quantity;
        Stock -= quantity;
        
        RaiseDomainEvent(new StockReservedDomainEvent(SkuId, AvailableStock));
        
        return Result.Ok();
    }
}