namespace TrailStore.Catalog.Api.Endpoints.GetProduct.Responses;

public class ProductSkuResponse
{
    public required Guid Id { get; init; }
    public required string Code { get; init; }
    public required decimal UnitPrice { get; init; }
    public required int Stock { get; init; }
    public required Guid[] OptionIds { get; init; } = [];
}