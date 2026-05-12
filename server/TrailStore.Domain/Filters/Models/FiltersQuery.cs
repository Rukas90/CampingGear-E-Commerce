using TrailStore.Domain.Shared.Enums;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Filters.Models;

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