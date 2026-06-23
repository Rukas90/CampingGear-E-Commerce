using System.Reflection;

namespace TrailStore.Shared.Infrastructure;

public static class SharedInfrastructureMarker
{
    public static Assembly Reference => typeof(SharedInfrastructureMarker).Assembly;
}