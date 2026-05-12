using TrailStore.Domain.Shared.Enums;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Products.Models;

public class ProductsFilter
{
    public ProductsSortBy SortBy { get; init; } = ProductsSortBy.Manual;
    public string[] BrandSlugs { get; init; } = [];
    public string[] CategorySlugs { get; init; } = [];
    public bool Pagination { get; init; } = false;
    public int Page { get; init; } = 0;
    public int PageSize { get; init; } = 30;
    public decimal PriceGte { get; init; } = 0m;
    public decimal PriceLte { get; init; } = decimal.MaxValue;
    public Availability Availability { get; init; } = Availability.All;
    public OptionSelection[] Option { get; init; } = [];
}