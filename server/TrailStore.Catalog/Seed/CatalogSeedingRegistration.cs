using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TrailStore.Catalog.Infrastructure.Database;
using TrailStore.Shared.Seeding;

namespace TrailStore.Catalog.Seed;

public static class CatalogSeedingRegistration
{
    public static HostApplicationBuilder AddCatalogSeeding(this HostApplicationBuilder builder)
    {
        builder.Services.AddCatalogContext(builder.Configuration);
        builder.Services.AddScoped<ISeedRunner, CatalogSeedRunner>();
        
        return builder;
    }
}