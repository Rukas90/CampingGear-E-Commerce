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
    public Task<Result> ReserveStock(StockReserveItem[] items, CancellationToken ct)
        => ModifyReservedItem(items, (invItem, stockItem) => invItem.Reserve(stockItem.Units), ct);

    public Task<Result> ConfirmReservedStock(StockReserveItem[] items, CancellationToken ct)
        => ModifyReservedItem(items, (invItem, stockItem) => invItem.Confirm(stockItem.Units), ct);

    public Task<Result> RevertReservedStock(StockReserveItem[] items, CancellationToken ct)
        => ModifyReservedItem(items, (invItem, stockItem) => invItem.Revert(stockItem.Units), ct);

    private async Task<Result> ModifyReservedItem(
        StockReserveItem[] items, Func<InventoryItem, StockReserveItem, Result> func, CancellationToken ct)
    {
        var inventoryItems = await GetInventoryItems(items, ct);
        
        foreach (var stockItem in items)
        {
            var invItem = inventoryItems.FirstOrDefault(i => i.SkuId == stockItem.SkuId);

            if (invItem is null)
            {
                return InventoryProblems.SkuNotFound(stockItem.SkuId);
            }

            var result = func(invItem, stockItem);

            if (!result.IsSuccess)
            {
                return result.Problem;
            }
        }
        
        await unitOfWork.SaveAsync(ct);
        
        return Result.Ok();
    }

    private Task<List<InventoryItem>> GetInventoryItems(StockReserveItem[] items, CancellationToken ct)
    => repository.GetBySkuIdsAsync(
        items.Select(item => item.SkuId), ct);
}