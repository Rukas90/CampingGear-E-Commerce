using TrailStore.Domain.Shared.Enums;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Products.Models;

public class ProductsFilter
{
    public required ProductsSortBy SortBy { get; init; } = ProductsSortBy.Manual;
    public required string[] BrandSlugs { get; init; } = [];
    public required string[] CategorySlugs { get; init; } = [];
    public required bool Pagination { get; init; } = false;
    public required int Page { get; init; } = 0;
    public required int PageSize { get; init; } = 30;
    public required decimal PriceGte { get; init; } = 0m;
    public required decimal PriceLte { get; init; } = decimal.MaxValue;
    public required Availability Availability { get; init; } = Availability.All;
    public required OptionSelection[] Option { get; init; } = [];
    public required string[] SkuCode { get; init; } = [];
}