using TrailStore.Inventory.Domain;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Inventory.Application.Abstractions;

public interface IInventoryItemRepository : IAggregateRepository<InventoryItem>
{
    Task<List<InventoryItem>> GetBySkuIdsAsync(IEnumerable<Guid> skuIds, CancellationToken ct);
}