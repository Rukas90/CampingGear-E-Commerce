using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Infrastructure.Database;
using TrailStore.Shared.Api.Registrations;
using TrailStore.Shared.Infrastructure.Extensions;

namespace TrailStore.Ordering;

public static class OrderingModuleRegistration
{
    public static ModuleHostBuilder AddOrderingModule(this ModuleHostBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        services.AddOrderingContext(configuration);

        services.AddOutbox<IOrderingOutbox, OrderingDbContext>();
        
        services.AddAppServicesFromAssemblies(OrderingMarker.Reference);
        
        services.ConfigureAppOptionsFromAssemblies(configuration, OrderingMarker.Reference);
        
        builder.AddApiAssembly(OrderingMarker.Reference);
        
        return builder;
    }
}