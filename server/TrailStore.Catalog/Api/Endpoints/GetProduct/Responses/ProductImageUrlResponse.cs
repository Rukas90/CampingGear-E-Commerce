namespace TrailStore.Catalog.Api.Endpoints.GetProduct.Responses;

public class ProductImageUrlResponse
{
    public required string Url { get; init; }
    public required int SortOrder { get; init; }
}