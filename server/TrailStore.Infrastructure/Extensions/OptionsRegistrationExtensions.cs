using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Extensions;

public static class OptionsRegistrationExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection ConfigureAppOptions<T>(IConfiguration configuration)
        {
            return services.ConfigureAppOptionsFromAssemblies(configuration, typeof(T).Assembly);
        }

        public IServiceCollection ConfigureAppOptionsFromAssemblies(IConfiguration configuration,
            params Assembly[] assemblies)
        {
            var method = typeof(OptionsConfigurationServiceCollectionExtensions)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .FirstOrDefault(m => m.Name == "Configure"
                                     && m.GetParameters().Length == 2
                                     && m.GetParameters()[1].ParameterType == typeof(IConfiguration));

            if (method is null) throw new Exception("Configure method not found");

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes()
                    .Where(type => type is { IsClass: true, IsAbstract: false })
                    .Where(type => type.GetCustomAttributes()
                        .Any(attr => attr.GetType() == typeof(AppOptionsAttribute)));

                foreach (var type in types)
                {
                    var attr = type.GetCustomAttribute<AppOptionsAttribute>()!;
                    var section = configuration.GetSection(attr.Key);
                    var invoker = method.MakeGenericMethod(type);

                    invoker.Invoke(null, [services, section]);
                }
            }

            return services;
        }
    }
}