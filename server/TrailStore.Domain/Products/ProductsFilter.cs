using TrailStore.Domain.Enums;

namespace TrailStore.Domain.Products;

public class ProductsFilter
{
    public SortBy         SortBy       { get; init; } = SortBy.Manual;
    public string?        BrandSlug    { get; init; } = null;
    public string?        CategorySlug { get; init; } = null;
    public bool           Pagination   { get; init; } = false;
    public int            Page         { get; init; } = 0;
    public int            PageSize     { get; init; } = 30;
    public decimal        PriceGte     { get; init; } = 0m;
    public decimal        PriceLte     { get; init; } = decimal.MaxValue;
    public Availability   Availability { get; init; } = Availability.All;
    public OptionFilter[] Option       { get; init; } = [];
}