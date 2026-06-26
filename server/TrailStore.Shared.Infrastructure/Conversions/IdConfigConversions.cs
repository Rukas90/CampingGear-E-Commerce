using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Domain.Utils;
using TrailStore.Shared.Infrastructure.Converters;

namespace TrailStore.Shared.Infrastructure.Conversions;

public static class IdConfigConversions
{
    public static void ConfigureIdConversion(ModelConfigurationBuilder config, Assembly[] assemblies)
    {
        var types = assemblies
            .SelectMany(a => ReflectionUtils.GetGenericInterfaceArguments(a, typeof(IIdentifier<>)))
            .Distinct();

        var conversion = ReflectionUtils.GetPrivateMethod(
            typeof(IdConfigConversions), nameof(ConfigureIdConverter));

        foreach (var type in types) ReflectionUtils.InvokeGeneric(conversion, type, config);
    }

    private static void ConfigureIdConverter<TType>(ModelConfigurationBuilder config)
    {
        config.Properties<Id<TType>>().HaveConversion<IdConverter<TType>>();
    }
}