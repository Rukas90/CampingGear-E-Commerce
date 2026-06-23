namespace TrailStore.Catalog.Api.Endpoints.GetProduct.Responses;

public sealed class ProductOptionGroupResponse
{
    public required string Name { get; init; }
    public int SortOrder { get; init; }
    public ProductOptionResponse[] Options { get; init; } = [];
}