using TrailStore.Inventory.Application.Abstractions;
using TrailStore.Inventory.Contracts;
using TrailStore.Inventory.Domain;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Inventory.Application;

[AppService<IInventoryService>]
internal sealed class InventoryService(
    IInventoryItemRepository repository,
    IInventoryUnitOfWork unitOfWork)
    : IInventoryService
{
    public async Task<Result> ReserveStock(StockReserveItem[] items, CancellationToken ct)
    {
        var inventoryItems = await repository.GetBySkuIdsAsync(
            items.Select(item => item.SkuId), ct);
        
        foreach (var item in items)
        {
            var invItem = inventoryItems.FirstOrDefault(i => i.SkuId == item.SkuId);

            if (invItem is null)
            {
                return InventoryProblems.SkuNotFound(item.SkuId);
            }
            
            var result = invItem.Reserve(item.Units);

            if (!result.IsSuccess)
            {
                return result.Problem;
            }
        }

        await unitOfWork.SaveAsync(ct);
        
        return Result.Ok();
    }
}