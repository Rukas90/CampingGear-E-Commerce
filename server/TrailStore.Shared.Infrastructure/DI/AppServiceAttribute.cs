using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace TrailStore.Shared.Infrastructure.DI;

[MeansImplicitUse]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class AppServiceAttribute<TService>(
    ServiceLifetime lifetime = ServiceLifetime.Scoped) : Attribute where TService : class
{
    public ServiceLifetime Lifetime { get; } = lifetime;
}