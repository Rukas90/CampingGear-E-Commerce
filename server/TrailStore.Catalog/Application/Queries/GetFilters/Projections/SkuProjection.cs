namespace TrailStore.Catalog.Application.Queries.GetFilters.Projections;

public sealed record SkuProjection(
    Guid ProductId,
    decimal UnitPrice,
    int Stock,
    BrandProjection Brand,
    CategoryProjection Category,
    IEnumerable<OptionProjection> Options);