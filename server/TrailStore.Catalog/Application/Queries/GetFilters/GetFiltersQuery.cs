using TrailStore.Catalog.Domain.Filters;
using TrailStore.Catalog.Domain.Options;
using TrailStore.Catalog.Domain.Products;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Catalog.Application.Queries.GetFilters;

public sealed record GetFiltersQuery(
    string? QueryBrand,
    string? QueryCategory,
    string[] FilterBrandSlugs,
    string[] FilterCategorySlugs,
    decimal FilterPriceGte,
    decimal FilterPriceLte,
    Availability FilterAvailability,
    OptionSelection[] FilterOption) : IQuery<CatalogFilters>;