using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Catalog.Application.Abstractions;
using TrailStore.Shared.Infrastructure.Constants;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Catalog.Infrastructure.Database;

public static class CatalogContextRegistration
{
    public static void AddCatalogContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CatalogDbContext>(options => 
            options.UsePostgres(configuration.GetConnectionString("DefaultConnection"), npgsql =>
            {
                npgsql.MigrationsHistoryTable(DatabaseConstants.MigrationsHistoryTable, DbDefaults.DefaultSchema);
            }));
        services.AddScoped<ICatalogUnitOfWork>(sp => sp.GetRequiredService<CatalogDbContext>());
    }
}