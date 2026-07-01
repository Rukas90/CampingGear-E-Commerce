using TrailStore.Shared.Domain.Common;

namespace TrailStore.Inventory.Domain;

public sealed class InventoryItem : AggregateRoot<InventoryItem>
{
    public required Guid SkuId { get; init; }
    public required int Stock { get; set; }
    public required int Reserved { get; set; }
    
    public int AvailableStock => Stock - Reserved;
    
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
}