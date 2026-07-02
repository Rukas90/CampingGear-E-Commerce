using Microsoft.EntityFrameworkCore;
using TrailStore.Inventory.Domain;
using TrailStore.Inventory.Infrastructure.Database;
using TrailStore.Seed.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Seed.Runners;

[AppService<ISeedRunner>]
internal class InventorySeedRunner(InventoryDbContext context) : SeedRunner
{
    public override string Identifier => "Inventory";
    
    protected override async Task DeleteAsync()
    {
        await context.InventoryItems.ExecuteDeleteAsync();
    }

    protected override void Seed()
    {
        context.InventoryItems.AddRange(Discover<InventoryItem>(ExecutingAssembly));
    }

    protected override Task Commit()
        => context.SaveChangesAsync();

    protected override Task<bool> IsSeededAsync()
        => context.InventoryItems.AnyAsync();
}