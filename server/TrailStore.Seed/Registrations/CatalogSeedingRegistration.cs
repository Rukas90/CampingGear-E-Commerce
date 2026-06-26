using TrailStore.Catalog.Infrastructure.Database;
using TrailStore.Seed.Common;
using TrailStore.Seed.Runners;

namespace TrailStore.Seed.Registrations;

public static class CatalogSeedingRegistration
{
    public static HostApplicationBuilder AddCatalogSeeding(this HostApplicationBuilder builder)
    {
        builder.Services.AddCatalogContext(builder.Configuration);
        builder.Services.AddScoped<ISeedRunner, CatalogSeedRunner>();
        
        return builder;
    }
}