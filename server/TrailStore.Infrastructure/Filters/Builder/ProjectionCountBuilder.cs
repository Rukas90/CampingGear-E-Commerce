using TrailStore.Infrastructure.Filters.Projections;

namespace TrailStore.Infrastructure.Filters.Builder;

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

    public int CountProducts(IReadOnlyList<SkuProjection> projections, IReadOnlyList<IProjectionFilter> ignore, Func<SkuProjection, bool> where)
        => projections
            .Where(where)
            .Where(projection => filters
                .Where(filter => !ignore.Contains(filter))
                .All(filter => filter.Filter(projection)))
            .DistinctBy(projection => projection.ProductId)
            .Count();
        
    public IEnumerable<SkuProjection> SelectSkus(IReadOnlyList<SkuProjection> projections, IReadOnlyList<IProjectionFilter> ignore)
        => projections
            .Where(projection => filters
                .Where(filter => !ignore.Contains(filter))
                .All(filter => filter.Filter(projection)));
}