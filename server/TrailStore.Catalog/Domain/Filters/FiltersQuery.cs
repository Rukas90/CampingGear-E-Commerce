using TrailStore.Catalog.Domain.Options;
using TrailStore.Catalog.Domain.Products;

namespace TrailStore.Catalog.Domain.Filters;

public class FiltersQuery
{
    public string? QueryBrand { get; init; }
    public string? QueryCategory { get; init; }

    public string[] FilterBrandSlugs { get; init; } = [];
    public string[] FilterCategorySlugs { get; init; } = [];
    public decimal FilterPriceGte { get; init; } = 0m;
    public decimal FilterPriceLte { get; init; } = decimal.MaxValue;
    public Availability FilterAvailability { get; init; } = Availability.All;
    public OptionSelection[] FilterOption { get; init; } = [];
}