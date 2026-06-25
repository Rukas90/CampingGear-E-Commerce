namespace TrailStore.Catalog.Application.Results;

public sealed class ProductOptionGroupResult
{
    public required string Name { get; init; }
    public int SortOrder { get; init; }
    public ProductOptionResult[] Options { get; init; } = [];
}