using JetBrains.Annotations;

namespace TrailStore.Shared.DependencyInjection;

[MeansImplicitUse]
[AttributeUsage(AttributeTargets.Class)]
public class AppOptionsAttribute(string key) : Attribute
{
    public readonly string Key = key;
}