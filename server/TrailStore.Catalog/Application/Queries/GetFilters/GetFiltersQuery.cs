using TrailStore.Catalog.Domain.Filters;
using TrailStore.Catalog.Domain.Options;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Catalog.Application.Queries.GetFilters;

public sealed record GetFiltersQuery : IQuery<CatalogFilters>
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