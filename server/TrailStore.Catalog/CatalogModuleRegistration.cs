using TrailStore.Catalog.Infrastructure.Database;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Registrations;
using TrailStore.Shared.Infrastructure.Extensions;

namespace TrailStore.Catalog;

public static class CatalogModuleRegistration
{
    public static ModuleHostBuilder AddCatalogModule(this ModuleHostBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        services.AddCatalogContext(configuration);
        
        services.AddAppServicesFromAssemblies(CatalogMarker.Reference);
        
        services.ConfigureAppOptionsFromAssemblies(configuration, CatalogMarker.Reference);
        
        builder.AddApiAssembly(CatalogMarker.Reference);
        
        return builder;
    }
}