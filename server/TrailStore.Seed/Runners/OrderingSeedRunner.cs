using Microsoft.EntityFrameworkCore;
using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Ordering.Infrastructure.Database;
using TrailStore.Seed.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Seed.Runners;

[AppService<ISeedRunner>]
internal class OrderingSeedRunner(OrderingDbContext context) : SeedRunner
{
    public override string Identifier => "Ordering";
    
    protected override async Task DeleteAsync()
    {
        await context.ShippingZones.ExecuteDeleteAsync();
        await context.ShippingMethods.ExecuteDeleteAsync();
    }

    protected override void Seed()
    {
        var assembly = typeof(OrderingSeedRunner).Assembly;
        
        context.ShippingMethods.AddRange(Discover<ShippingMethod>(assembly));
        context.ShippingZones.AddRange(Discover<ShippingZone>(assembly));
    }

    protected override Task Commit()
        => context.SaveChangesAsync();

    protected override Task<bool> IsSeededAsync()
        => context.ShippingMethods.AnyAsync();
}