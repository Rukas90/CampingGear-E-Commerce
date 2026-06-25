namespace TrailStore.Catalog.Application.Results;

public sealed class ProductImageResult
{
    public required Guid? OptionId { get; init; }
    public required ProductImageUrlResult[] Urls { get; init; } = [];
}