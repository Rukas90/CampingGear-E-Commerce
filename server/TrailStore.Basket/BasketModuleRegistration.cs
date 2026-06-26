using TrailStore.Basket.Infrastructure.Database;
using TrailStore.Shared.Api.Registrations;
using TrailStore.Shared.Infrastructure.Extensions;

namespace TrailStore.Basket;

public static class BasketModuleRegistration
{
    public static ModuleHostBuilder AddBasketModule(this ModuleHostBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        services.AddBasketContext(configuration);
        
        services.AddAppServicesFromAssemblies(BasketMarker.Reference);

        services.ConfigureAppOptionsFromAssemblies(configuration, BasketMarker.Reference);
        
        builder.AddApiAssembly(BasketMarker.Reference);
        
        return builder;
    }
}