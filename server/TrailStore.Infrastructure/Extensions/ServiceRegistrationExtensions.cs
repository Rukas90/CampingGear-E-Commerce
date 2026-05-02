using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Extensions;

public static class ServiceRegistrationExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddAppServices<T>() 
            => services.AddAppServicesFromAssemblies(typeof(T).Assembly);

        public IServiceCollection AddAppServicesFromAssemblies(params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var implementationTypes = assembly.GetTypes()
                    .Where(type => type is { IsClass: true, IsAbstract: false })
                    .Where(type => type.GetCustomAttributes()
                        .Any(attr => attr.GetType().IsGenericType &&
                                     attr.GetType().GetGenericTypeDefinition() == typeof(AppServiceAttribute<>)));

                foreach (var type in implementationTypes)
                {
                    var attributes = type.GetCustomAttributes()
                        .Where(attr => attr.GetType().IsGenericType &&
                                       attr.GetType().GetGenericTypeDefinition() == typeof(AppServiceAttribute<>));

                    foreach (var attr in attributes)
                    {
                        var serviceType = attr.GetType().GetGenericArguments()[0];
                        var lifetime = (ServiceLifetime)attr.GetType()
                            .GetProperty(nameof(AppServiceAttribute<object>.Lifetime))!
                            .GetValue(attr)!;

                        if (!serviceType.IsAssignableFrom(type))
                        {
                            throw new InvalidOperationException(
                                $"{type.FullName} does not implement {serviceType.FullName}");
                        }

                        services.Add(new ServiceDescriptor(serviceType, type, lifetime));
                    }
                }
            }

            return services;
        }
    }
}