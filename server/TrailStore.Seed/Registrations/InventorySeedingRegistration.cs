using TrailStore.Inventory.Infrastructure.Database;
using TrailStore.Seed.Common;
using TrailStore.Seed.Runners;

namespace TrailStore.Seed.Registrations;

public static class InventorySeedingRegistration
{
    public static HostApplicationBuilder AddInventorySeeding(this HostApplicationBuilder builder)
    {
        builder.Services.AddInventoryContext(builder.Configuration);
        builder.Services.AddScoped<ISeedRunner, InventorySeedRunner>();
        
        return builder;
    }
}