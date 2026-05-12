using Microsoft.EntityFrameworkCore;
using TrailStore.Domain;
using TrailStore.Infrastructure.Data.Converters;
using TrailStore.Shared.Common;
using TrailStore.Shared.Utils;

namespace TrailStore.Infrastructure.Data.Config;

public static class IdConfigConversions
{
    public static void ConfigureIdConversion(ModelConfigurationBuilder config)
    {
        var types = ReflectionUtils.GetGenericInterfaceArguments(
            DomainAssembly.Reference,
            typeof(IIdentifier<>));

        var conversion = ReflectionUtils.GetPrivateMethod(
            typeof(IdConfigConversions), nameof(ConfigureIdConverter));

        foreach (var type in types) ReflectionUtils.InvokeGeneric(conversion, type, config);
    }

    private static void ConfigureIdConverter<TType>(ModelConfigurationBuilder config)
    {
        config.Properties<Id<TType>>().HaveConversion<IdConverter<TType>>();
    }
}