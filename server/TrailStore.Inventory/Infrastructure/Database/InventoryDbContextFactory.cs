using Microsoft.EntityFrameworkCore;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Inventory.Infrastructure.Database;

// ReSharper disable once UnusedType.Global
public class InventoryDbContextFactory : ModuleDbContextFactory<InventoryDbContext>
{
    protected override string Schema => DbDefaults.DefaultSchema;
    protected override InventoryDbContext CreateContext(DbContextOptions<InventoryDbContext> options) => new(options);
}