using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.Conversions;
using TrailStore.Shared.Infrastructure.Converters;

namespace TrailStore.Shared.Infrastructure.Configurations;

public static class DatabaseConventionConfiguration
{
    public static void ApplyDefaultConventions(ModelConfigurationBuilder config, params Assembly[] assemblies) 
    {
        IdConfigConversions.ConfigureIdConversion(config, assemblies);
        config.Properties<Slug>().HaveConversion<SlugConverter>();
    }
}