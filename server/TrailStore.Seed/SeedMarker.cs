using System.Reflection;

namespace TrailStore.Seed;

public static class SeedMarker
{
    public static readonly Assembly Reference = typeof(SeedMarker).Assembly;
}