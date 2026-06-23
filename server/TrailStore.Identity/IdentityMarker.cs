using System.Reflection;

namespace TrailStore.Identity;

public static class IdentityMarker
{
    public static readonly Assembly Reference = typeof(IdentityMarker).Assembly;
}