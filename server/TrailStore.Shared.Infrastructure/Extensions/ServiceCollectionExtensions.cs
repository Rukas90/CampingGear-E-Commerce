using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Caching;
using TrailStore.Shared.Domain.Events;
using TrailStore.Shared.Infrastructure.Caching;
using TrailStore.Shared.Infrastructure.Events;
using TrailStore.Shared.Infrastructure.Persistence;
using TrailStore.Shared.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// ReSharper disable UnusedMethodReturnValue.Global

namespace TrailStore.Shared.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    
    extension(IServiceCollection services)
    {
        public IServiceCollection AddRedisCache(IConfiguration configuration)
        {
            services.AddSingleton<IRedisCacheService, RedisCacheService>();
            services.AddSingleton<IConnectionMultiplexer>(
                ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis") 
                                              ?? throw new InvalidOperationException("Redis connection string is required.")));
            
            return services;
        }

        public IServiceCollection AddTrailStoreOutputCache(
            IConfiguration configuration, IWebHostEnvironment environment, ILogger logger)
        {
            var connectionString = configuration.GetConnectionString("Redis");
            var isProduction = environment.IsProduction() || environment.IsStaging();
            
            if (isProduction && !string.IsNullOrEmpty(connectionString))
            {
                services.AddStackExchangeRedisOutputCache(options =>
                {
                    options.Configuration = connectionString;
                    options.InstanceName = "TrailStore";
                });
                
                return services;
            }

            if (isProduction)
            {
                logger.LogWarning("Redis connection string is missing in Production. Falling back to in-memory Output Cache.");
            }
            
            services.AddOutputCache();
            
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