using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable All

namespace TrailStore.Shared.Common;

[MeansImplicitUse]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class AppServiceAttribute<TService>(
    ServiceLifetime lifetime = ServiceLifetime.Scoped) : Attribute where TService : class
{
    public ServiceLifetime Lifetime { get; } = lifetime;
}