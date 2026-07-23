using TrailStore.Inventory.Application.Abstractions;
using TrailStore.Inventory.Infrastructure.Database;
using TrailStore.Shared.Api.Registrations;
using TrailStore.Shared.Infrastructure.Extensions;

namespace TrailStore.Inventory;

public static class InventoryModuleRegistration
{
    public static ModuleHostBuilder AddInventoryModule(this ModuleHostBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;
        
        services.AddInventoryContext(configuration);
        
        services.AddAppServicesFromAssemblies(InventoryMarker.Reference);

        services.ConfigureAppOptionsFromAssemblies(configuration, InventoryMarker.Reference);
        
        return builder;
    }
}