using TrailStore.Catalog.Domain.Options;
using TrailStore.Catalog.Domain.Products;

namespace TrailStore.Catalog.Domain.Filters;

public class ProductsFilter
{
    public required ProductsSortBy SortBy { get; init; } = ProductsSortBy.Manual;
    public required string[] Brands { get; init; } = [];
    public required string[] Categories { get; init; } = [];
    public required bool Pagination { get; init; } = false;
    public required int Page { get; init; } = 0;
    public required int PageSize { get; init; } = 30;
    public required decimal PriceGte { get; init; } = 0m;
    public required decimal PriceLte { get; init; } = decimal.MaxValue;
    public required Availability Availability { get; init; } = Availability.All;
    public required OptionSelection[] Option { get; init; } = [];
    public required string[] SkuCode { get; init; } = [];
}