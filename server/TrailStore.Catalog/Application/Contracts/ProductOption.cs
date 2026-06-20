using TrailStore.Catalog.Domain.Options;

namespace TrailStore.Catalog.Application.Contracts;

public sealed class ProductOption
{
    public required string Name { get; init; }
    public required int SortOrder { get; init; }
    public required bool InStock { get; init; }
    public PreviewType? PreviewType { get; init; }
    public string? PreviewValue { get; init; }
}