namespace TrailStore.Catalog.Api.Endpoints.GetProduct.Responses;

public class ProductImageResponse
{
    public required Guid? OptionId { get; init; }
    public required ProductImageUrlResponse[] Urls { get; init; } = [];
}