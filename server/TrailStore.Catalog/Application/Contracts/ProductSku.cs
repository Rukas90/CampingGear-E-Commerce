namespace TrailStore.Catalog.Application.Contracts;

public class ProductSku
{
    public required string Code { get; init; }
    public required decimal UnitPrice { get; init; }
    public required int Stock { get; init; }
    public required Guid[] OptionIds { get; init; } = [];
}