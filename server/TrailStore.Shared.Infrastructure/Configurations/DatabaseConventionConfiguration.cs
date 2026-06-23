using Microsoft.EntityFrameworkCore;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.Conversions;
using TrailStore.Shared.Infrastructure.Converters;

namespace TrailStore.Shared.Infrastructure.Configurations;

public static class DatabaseConventionConfiguration
{
    public static void ApplyDefaultConventions<TContext>(ModelConfigurationBuilder config) 
        where TContext : DbContext
    {
        IdConfigConversions.ConfigureIdConversion(config, typeof(TContext).Assembly);
        config.Properties<Slug>().HaveConversion<SlugConverter>();
    }
}