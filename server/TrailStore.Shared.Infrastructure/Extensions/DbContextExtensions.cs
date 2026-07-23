using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Infrastructure.Constants;
using TrailStore.Shared.Infrastructure.Outbox;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Shared.Infrastructure.Extensions;

public static class DbContextExtensions
{
    // ReSharper disable once UnusedMethodReturnValue.Global
    extension(IServiceCollection services)
    {
        public IServiceCollection AddModuleDbContext<TContext, TUnitOfWork>(IConfiguration configuration,
            string schema,
            Action<IServiceProvider, DbContextOptionsBuilder>? configureOptions = null,
            string connectionString = "DefaultConnection")
            where TContext : BaseDbContext<TContext>, TUnitOfWork
            where TUnitOfWork : class, IUnitOfWork
        {
            services.AddDbContext<TContext>((sp, options) =>
            {
                options.UsePostgres(
                    configuration.GetConnectionString(connectionString),
                    npgsql => npgsql
                        .MigrationsHistoryTable(DatabaseConstants.MigrationsHistoryTable, schema)
                        .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            
                options.AddInterceptors(sp.GetRequiredService<DomainEventPublishInterceptor>());
            
                configureOptions?.Invoke(sp, options);
            });

            services.AddScoped<TUnitOfWork>(sp => sp.GetRequiredService<TContext>());

            return services;
        }

        public IServiceCollection AddModuleDbContext<TContext, TUnitOfWork, TOutbox>(IConfiguration configuration,
            string schema,
            Action<IServiceProvider, DbContextOptionsBuilder>? configureOptions = null,
            string connectionString = "DefaultConnection")
            where TContext : BaseDbContext<TContext>, TUnitOfWork, TOutbox
            where TUnitOfWork : class, IUnitOfWork
            where TOutbox : class, IOutbox
        {
            services.AddModuleDbContext<TContext, TUnitOfWork>(
                configuration,
                schema,
                (sp, options) =>
                {
                    options.AddInterceptors(sp.GetRequiredService<OutboxSignalInterceptor<TOutbox>>());
                    configureOptions?.Invoke(sp, options);
                },
                connectionString);

            services.AddOutbox<TOutbox, TContext>();

            return services;
        }
    }

    extension(IServiceProvider services)
    {
        public async Task MigrateAllAsync(params Type[] contextTypes)
        {
            using var scope = services.CreateScope();

            foreach (var contextType in contextTypes)
            {
                var db = (DbContext)scope.ServiceProvider.GetRequiredService(contextType);
            
                await db.Database.MigrateAsync();
            }
        }

        public async Task MigrateAsync<TContext>()
            where TContext : DbContext
        {
            using var scope = services.CreateScope();
        
            var db = scope.ServiceProvider.GetRequiredService<TContext>();
        
            await db.Database.MigrateAsync();
        }
    }
}