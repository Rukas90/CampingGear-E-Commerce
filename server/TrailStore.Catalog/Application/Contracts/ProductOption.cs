using TrailStore.Catalog.Domain.Options;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Application.Contracts;

public sealed class ProductOption
{
    public Id<Option> Id { get; init; }
    public required string Name { get; init; }
    public required int SortOrder { get; init; }
    public required bool InStock { get; init; }
    public PreviewType? PreviewType { get; init; }
    public string? PreviewValue { get; init; }
}