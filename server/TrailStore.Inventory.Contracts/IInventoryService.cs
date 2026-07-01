using TrailStore.Shared.Domain.Common;

namespace TrailStore.Inventory.Contracts;

public interface IInventoryService
{
    Task<Result> ReserveStock(StockReserveItem[] items, CancellationToken ct);
}