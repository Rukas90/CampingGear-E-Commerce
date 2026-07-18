using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Caching;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.Caching;
using TrailStore.Shared.Infrastructure.Events;
using TrailStore.Shared.Infrastructure.Persistence;
using TrailStore.Shared.Infrastructure.Security;

// ReSharper disable UnusedMethodReturnValue.Global

namespace TrailStore.Shared.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    
    extension(IServiceCollection services)
    {
        public IServiceCollection AddRedisCache(string connectionString)
        {
            services.AddSingleton<IRedisCacheService, RedisCacheService>();
            services.AddSingleton<IConnectionMultiplexer>(
                ConnectionMultiplexer.Connect(connectionString));
    
            return services;
        }

        public IServiceCollection AddPasswordHasher()
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
    
            return services;
        }
        
        public IServiceCollection AddEventPublishing()
        {
            services.AddScoped<DomainEventPublishInterceptor>();
            services.AddScoped<IEventPublisher, EventPublisher>();
    
            return services;
        }
    }
}