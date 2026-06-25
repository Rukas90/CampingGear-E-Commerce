namespace TrailStore.Catalog.Application.Results;

public class ProductSkuResult
{
    public required string Code { get; init; }
    public required decimal UnitPrice { get; init; }
    public required int Stock { get; init; }
    public required Guid[] OptionIds { get; init; } = [];
}