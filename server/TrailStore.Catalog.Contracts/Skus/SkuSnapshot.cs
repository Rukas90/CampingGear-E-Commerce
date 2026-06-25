using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Contracts.Skus;

public class SkuSnapshot
{
    public required Id<SkuRef> Id { get; init; }
    public required EntityIdentifier Product { get; init; }
    public required EntityIdentifier Brand { get; init; }
    public required decimal UnitPrice { get; init; }
    public required int Stock { get; init; }
    public string? ThumbnailUrl { get; init; }
    public required SkuOptionSnapshot[] Options { get; init; }
}