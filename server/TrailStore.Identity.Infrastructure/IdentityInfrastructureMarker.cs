using System.Reflection;

namespace TrailStore.Identity.Infrastructure;

public static class IdentityInfrastructureMarker
{
    public static readonly Assembly Reference = typeof(IdentityInfrastructureMarker).Assembly;
}