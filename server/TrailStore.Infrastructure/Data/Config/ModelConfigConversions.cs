using Microsoft.EntityFrameworkCore;
using TrailStore.Domain;
using TrailStore.Shared.Common;
using TrailStore.Infrastructure.Data.Converters;
using TrailStore.Shared.Utils;

namespace TrailStore.Infrastructure.Data.Config;

public static class ModelConfigConversions
{
    public static void ConfigureModelIdConversion(ModelConfigurationBuilder config)
    {
        var types = ReflectionUtils.GetGenericInterfaceArguments(
            assembly:             DomainAssembly.Reference, 
            openGenericInterface: typeof(IModel<>));

        var conversion = ReflectionUtils.GetPrivateMethod(
            typeof(ModelConfigConversions), nameof(ConfigureIdConverter));

        foreach (var type in types)
        {
            ReflectionUtils.InvokeGeneric(conversion, type, config);
        }
    }
    
    private static void ConfigureIdConverter<TType>(ModelConfigurationBuilder config)
    {
        config.Properties<Id<TType>>()
            .HaveConversion<IdConverter<TType>>();
    }
}