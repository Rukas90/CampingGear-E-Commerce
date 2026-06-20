using TrailStore.Catalog.Domain.Options;

namespace TrailStore.Catalog.Application.Queries.GetFilters.Projections;

public sealed record OptionProjection(
    string Name,
    string Slug,
    int SortOrder,
    PreviewType? PreviewType,
    string? PreviewValue,
    OptionGroupProjection Group);