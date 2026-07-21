using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Catalog.Application.Abstractions;
using TrailStore.Shared.Infrastructure.Extensions;

namespace TrailStore.Catalog.Infrastructure.Database;

public static class CatalogContextRegistration
{
    public static void AddCatalogContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddModuleDbContext<CatalogDbContext, ICatalogUnitOfWork>(configuration, DbDefaults.DefaultSchema);
}