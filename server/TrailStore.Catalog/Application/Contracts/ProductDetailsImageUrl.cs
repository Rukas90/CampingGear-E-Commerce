namespace TrailStore.Catalog.Application.Contracts;

public sealed class ProductDetailsImageUrl
{
    public required string Url { get; init; }
    public required int SortOrder { get; init; }
}