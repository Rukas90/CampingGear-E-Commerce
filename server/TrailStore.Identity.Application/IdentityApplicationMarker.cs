using System.Reflection;

namespace TrailStore.Identity.Application;

public static class IdentityApplicationMarker
{
    public static readonly Assembly Reference = typeof(IdentityApplicationMarker).Assembly;
}