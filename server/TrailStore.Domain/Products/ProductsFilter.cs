using TrailStore.Domain.Enums;

namespace TrailStore.Domain.Products;

public readonly record struct OptionFilter(string GroupSlug, string ValueSlug)
{
    public bool IsValid => !string.IsNullOrEmpty(GroupSlug) && !string.IsNullOrEmpty(ValueSlug);
}

public class ProductsFilter
{
    public SortBy         SortBy       { get; init; } = SortBy.Manual;
    public string?        BrandSlug    { get; init; } = null;
    public string?        CategorySlug { get; init; } = null;
    public int            Page         { get; init; } = 0;
    public decimal        PriceGte     { get; init; } = 0m;
    public decimal        PriceLte     { get; init; } = decimal.MaxValue;
    public Availability   Availability { get; init; } = Availability.All;
    public OptionFilter[] Options      { get; init; } = [];
}