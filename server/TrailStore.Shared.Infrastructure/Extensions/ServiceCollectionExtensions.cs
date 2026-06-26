using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using TrailStore.Shared.Domain.Caching;
using TrailStore.Shared.Infrastructure.Caching;

// ReSharper disable UnusedMethodReturnValue.Global

namespace TrailStore.Shared.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedInfrastructure(
        this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IConnectionMultiplexer>(
            ConnectionMultiplexer.Connect(config.GetConnectionString("Redis")!));

        services.AddAppServicesFromAssemblies(SharedInfrastructureMarker.Reference);
        services.AddSingleton<IRedisCacheService, RedisCacheService>();
    
        return services;
    }
}