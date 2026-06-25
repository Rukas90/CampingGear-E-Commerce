namespace TrailStore.Catalog.Application.Results;

public sealed class ProductImageUrlResult
{
    public required string Url { get; init; }
    public required int SortOrder { get; init; }
}