using System.Reflection;

namespace TrailStore.Catalog;

public static class CatalogMarker
{
    public static readonly Assembly Reference = typeof(CatalogMarker).Assembly;
}