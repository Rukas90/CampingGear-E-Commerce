namespace TrailStore.Catalog.Application.Contracts;

public sealed class ProductDetailsImage
{
    public required Guid? OptionId { get; init; }
    public required ProductDetailsImageUrl[] Urls { get; init; } = [];
}