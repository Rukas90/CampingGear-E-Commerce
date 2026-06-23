using TrailStore.Catalog.Domain.Products;

namespace TrailStore.Catalog.Api.Endpoints.GetProducts;

public record GetProductsRequest
{
    public ProductsSortBy? SortBy { get; init; }
    public string[]? Brand { get; init; }
    public string[]? Category { get; init; }
    public bool? Pagination { get; init; }
    public int? Page { get; init; }
    public int? PageSize { get; init; }
    public decimal? PriceGte { get; init; }
    public decimal? PriceLte { get; init; }
    public Availability? Availability { get; init; }
    public Dictionary<string, string>? Option { get; init; }
    public string[]? SkuCode { get; init; }
}