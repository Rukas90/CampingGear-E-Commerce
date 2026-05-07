namespace TrailStore.Infrastructure.Filters.Projections;

internal sealed record SkuProjection(
    Guid ProductId,
    decimal UnitPrice,
    int Stock,
    BrandProjection Brand,
    CategoryProjection Category,
    IEnumerable<OptionProjection> Options);