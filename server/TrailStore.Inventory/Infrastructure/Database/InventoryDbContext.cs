using Microsoft.EntityFrameworkCore;
using TrailStore.Inventory.Application.Abstractions;
using TrailStore.Inventory.Domain;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Inventory.Infrastructure.Database;

[AppService<IInventoryUnitOfWork>]
public sealed class InventoryDbContext(DbContextOptions<InventoryDbContext> options)
    : BaseDbContext<InventoryDbContext>(options), IInventoryUnitOfWork
{
    protected override string DefaultSchema => DbDefaults.DefaultSchema;
    
    public DbSet<InventoryItem> InventoryItems { get; set; }
}