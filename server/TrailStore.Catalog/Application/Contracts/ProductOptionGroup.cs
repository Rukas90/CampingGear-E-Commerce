namespace TrailStore.Catalog.Application.Contracts;

public sealed class ProductOptionGroup
{
    public required string Name { get; init; }
    public int SortOrder { get; init; }
    public ProductOption[] Options { get; init; } = [];
}