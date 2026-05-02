using JetBrains.Annotations;

namespace TrailStore.Shared.Common;

[MeansImplicitUse]
[AttributeUsage(AttributeTargets.Class)]
public class AppOptionsAttribute(string key) : Attribute
{
    public readonly string Key = key;
}