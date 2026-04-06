using TrailStore.Domain.Enums;

namespace TrailStore.Api.Products.Dto;

public class ProductsRequest
{
    public SortBy?                SortBy       { get; init; }
    public string?                Brand        { get; init; }
    public string?                Category     { get; init; }
    public int?                   Page         { get; init; }
    public decimal?               PriceGte     { get; init; }
    public decimal?               PriceLte     { get; init; }
    public Availability?          Availability { get; init; }
    public IReadOnlyList<string>? Option       { get; init; }
}