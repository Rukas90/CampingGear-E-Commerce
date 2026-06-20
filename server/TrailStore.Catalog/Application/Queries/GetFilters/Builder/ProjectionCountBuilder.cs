using TrailStore.Catalog.Application.Queries.GetFilters.Projections;

namespace TrailStore.Catalog.Application.Queries.GetFilters.Builder;

internal sealed class ProjectionCountBuilder
{
    private readonly HashSet<IProjectionFilter> filters = [];

    public static ProjectionCountBuilder With(params IProjectionFilter[] filters)
    {
        ProjectionCountBuilder builder = new();

        foreach (var filter in filters)
        {
            builder.filters.Add(filter);
        }

        return builder;
    }

    public int CountProducts(
        IReadOnlyList<SkuProjection> projections, 
        IReadOnlyList<IProjectionFilter> ignore, 
        Func<SkuProjection, bool> where)
    {
        return projections
            .Where(where)
            .Where(projection => filters
                .Where(filter => !ignore.Contains(filter))
                .All(filter => filter.Filter(projection)))
            .DistinctBy(projection => projection.ProductId)
            .Count();
    }

    public IEnumerable<SkuProjection> SelectSkus(
        IReadOnlyList<SkuProjection> projections, 
        IReadOnlyList<IProjectionFilter> ignore)
    {
        return projections
            .Where(projection => filters
                .Where(filter => !ignore.Contains(filter))
                .All(filter => filter.Filter(projection)));
    }
}