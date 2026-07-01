using Microsoft.EntityFrameworkCore;
using TrailStore.Inventory.Application.Abstractions;
using TrailStore.Inventory.Domain;
using TrailStore.Inventory.Infrastructure.Database;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Inventory.Infrastructure;

[AppService<IInventoryItemRepository>]
public sealed class InventoryItemRepository(InventoryDbContext _context) 
    : AggregateRepository<InventoryItem, InventoryDbContext>(_context), IInventoryItemRepository
{
    public Task<List<InventoryItem>> GetBySkuIdsAsync(IEnumerable<Guid> skuIds, CancellationToken ct)
        => AggregateWriteQuery.Where(item => skuIds.Contains(item.SkuId)).ToListAsync(ct);
}