using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Infrastructure.Constants;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Shared.Infrastructure.Extensions;

public static class DbContextExtensions
{
    // ReSharper disable once UnusedMethodReturnValue.Global
    public static IServiceCollection AddModuleDbContext<TContext, TUnitOfWork>(
        this IServiceCollection services,
        IConfiguration configuration,
        string schema,
        string connectionString = "DefaultConnection")
        where TContext : BaseDbContext<TContext>, TUnitOfWork
        where TUnitOfWork : class, IUnitOfWork
    {
        services.AddDbContext<TContext>((sp, options) =>
        {
            options.UsePostgres(
                configuration.GetConnectionString(connectionString),
                npgsql => npgsql.MigrationsHistoryTable(DatabaseConstants.MigrationsHistoryTable, schema));
            
            options.AddInterceptors(sp.GetRequiredService<DomainEventPublishInterceptor>());
        });

        services.AddScoped<TUnitOfWork>(sp => sp.GetRequiredService<TContext>());

        return services;
    }
}