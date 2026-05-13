using TrailStore.Domain.Filters.Models;
using TrailStore.Infrastructure.Filters.Projections;

namespace TrailStore.Infrastructure.Filters.Builder;

internal static class CatalogBuilder
{
    public static CatalogFilters Build(IReadOnlyList<SkuProjection> skus, FiltersQuery query)
    {
        var brandFilter = new BrandProjectionFilter(query.FilterBrandSlugs);
        var categoryFilter = new CategoryProjectionFilter(query.FilterCategorySlugs);
        var priceFilter = new PriceProjectionFilter(query.FilterPriceGte, query.FilterPriceLte);
        var availabilityFilter = new AvailabilityProjectionFilter(query.FilterAvailability);

        var optionFilters = query.FilterOption.Select(option => new OptionProjectionFilter(option)).ToArray();

        var counter = ProjectionCountBuilder.With(
            new IProjectionFilter[] { brandFilter, categoryFilter, priceFilter, availabilityFilter }
                .Concat(optionFilters).ToArray());

        return new CatalogFilters
        {
            Brands = skus
                .GroupBy(projection => projection.Brand)
                .Select(projections => new FilterValue
                {
                    Name = projections.Key.Name,
                    Slug = projections.Key.Slug,
                    Count = counter.CountProducts(skus, [brandFilter], sku => sku.Brand.Id == projections.Key.Id)
                })
                .ToArray(),

            Categories = skus.GroupBy(projection => projection.Category)
                .Select(projections => new FilterValue
                {
                    Name = projections.Key.Name,
                    Slug = projections.Key.Slug,
                    Count = counter.CountProducts(skus, [categoryFilter], sku => sku.Category.Id == projections.Key.Id)
                })
                .ToArray(),

            MinPrice = counter.SelectSkus(skus, [priceFilter]).MinBy(s => s.UnitPrice)?.UnitPrice ?? 0,
            MaxPrice = counter.SelectSkus(skus, [priceFilter]).MaxBy(s => s.UnitPrice)?.UnitPrice ?? 0,
            InStock = counter.SelectSkus(skus, [availabilityFilter]).GroupBy(s => s.ProductId)
                .Count(g => g.Any(s => s.Stock > 0)),
            OutOfStock = counter.SelectSkus(skus, [availabilityFilter]).GroupBy(s => s.ProductId)
                .Count(g => g.All(s => s.Stock <= 0)),
            Options = skus.SelectMany(projection => projection.Options)
                .GroupBy(o => o.Group.Slug)
                .Select(g =>
                {
                    var groupFilter = optionFilters.FirstOrDefault(f => f.Option.GroupSlug == g.Key);

                    return new
                    {
                        g.First().Group,
                        Options = g.DistinctBy(projection => projection.Slug)
                            .Select(projection => new OptionFilter
                            {
                                Name = projection.Name,
                                Slug = projection.Slug,
                                SortOrder = projection.SortOrder,
                                PreviewType = projection.PreviewType,
                                PreviewValue = projection.PreviewValue,
                                Count = counter.CountProducts(
                                    skus,
                                    groupFilter != null ? [groupFilter] : [],
                                    sku => sku.Options.Any(option => option.Group.Slug == projection.Group.Slug 
                                                                     && option.Slug == projection.Slug))
                            }).ToArray()
                    };
                })
                .Select(g => new OptionGroupFilter
                {
                    Name = g.Group.Name,
                    Slug = g.Group.Slug,
                    SortOrder = g.Group.SortOrder,
                    Options = g.Options
                })
                .ToArray()
        };
    }
}