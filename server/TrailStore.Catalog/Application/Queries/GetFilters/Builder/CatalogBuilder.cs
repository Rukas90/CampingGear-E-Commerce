using TrailStore.Catalog.Application.Queries.GetFilters.Projections;
using TrailStore.Catalog.Domain.Filters;

namespace TrailStore.Catalog.Application.Queries.GetFilters.Builder;

internal static class CatalogBuilder
{
    public static CatalogFilters Build(IReadOnlyList<SkuProjection> skus, GetFiltersQuery query)
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
            Brands = BuildBrandFilters(skus, counter, brandFilter),
            Categories = BuildCategoryFilters(skus, counter, categoryFilter),
            MinPrice = GetMinPrice(skus, counter, priceFilter),
            MaxPrice = GetMaxPrice(skus, counter, priceFilter),
            InStock = CountInStock(skus, counter, availabilityFilter),
            OutOfStock = CountOutOfStock(skus, counter, availabilityFilter),
            Options = BuildOptionGroupFilters(skus, counter, optionFilters)
        };
    }
    
    private static FilterValue[] BuildBrandFilters(
        IReadOnlyList<SkuProjection> skus,
        ProjectionCountBuilder counter,
        BrandProjectionFilter brandFilter)
    {
        return skus
            .GroupBy(projection => projection.Brand)
            .Select(projections => new FilterValue
            {
                Name = projections.Key.Name,
                Slug = projections.Key.Slug,
                Count = counter.CountProducts(skus, [brandFilter], sku => sku.Brand.Id == projections.Key.Id)
            })
            .ToArray();
    }
    
    private static FilterValue[] BuildCategoryFilters(
        IReadOnlyList<SkuProjection> skus,
        ProjectionCountBuilder counter,
        CategoryProjectionFilter categoryFilter)
    {
        return skus
            .GroupBy(projection => projection.Category)
            .Select(projections => new FilterValue
            {
                Name = projections.Key.Name,
                Slug = projections.Key.Slug,
                Count = counter.CountProducts(skus, [categoryFilter], sku => sku.Category.Id == projections.Key.Id)
            })
            .ToArray();
    }
 
    private static decimal GetMinPrice(
        IReadOnlyList<SkuProjection> skus,
        ProjectionCountBuilder counter,
        PriceProjectionFilter priceFilter)
    {
        return counter.SelectSkus(skus, [priceFilter]).MinBy(s => s.UnitPrice)?.UnitPrice ?? 0;
    }
 
    private static decimal GetMaxPrice(
        IReadOnlyList<SkuProjection> skus,
        ProjectionCountBuilder counter,
        PriceProjectionFilter priceFilter)
    {
        return counter.SelectSkus(skus, [priceFilter]).MaxBy(s => s.UnitPrice)?.UnitPrice ?? 0;
    }
 
    private static int CountInStock(
        IReadOnlyList<SkuProjection> skus,
        ProjectionCountBuilder counter,
        AvailabilityProjectionFilter availabilityFilter)
    {
        return counter.SelectSkus(skus, [availabilityFilter])
            .GroupBy(s => s.ProductId)
            .Count(g => g.Any(s => s.Stock > 0));
    }
 
    private static int CountOutOfStock(
        IReadOnlyList<SkuProjection> skus,
        ProjectionCountBuilder counter,
        AvailabilityProjectionFilter availabilityFilter)
    {
        return counter.SelectSkus(skus, [availabilityFilter])
            .GroupBy(s => s.ProductId)
            .Count(g => g.All(s => s.Stock <= 0));
    }
 
    private static OptionGroupFilter[] BuildOptionGroupFilters(
        IReadOnlyList<SkuProjection> skus,
        ProjectionCountBuilder counter,
        OptionProjectionFilter[] optionFilters)
    {
        return skus
            .SelectMany(projection => projection.Options)
            .GroupBy(o => o.Group.Slug)
            .Select(g => BuildOptionGroup(g, skus, counter, optionFilters))
            .Select(g => new OptionGroupFilter
            {
                Name = g.Group.Name,
                Slug = g.Group.Slug,
                SortOrder = g.Group.SortOrder,
                Options = g.Options
            })
            .ToArray();
    }
 
    private static (OptionGroupProjection Group, OptionFilter[] Options) BuildOptionGroup(
        IGrouping<string, OptionProjection> group,
        IReadOnlyList<SkuProjection> skus,
        ProjectionCountBuilder counter,
        OptionProjectionFilter[] optionFilters)
    {
        var groupFilter = optionFilters.FirstOrDefault(f => f.Option.GroupSlug == group.Key);
 
        var options = group
            .DistinctBy(projection => projection.Slug)
            .Select(projection => BuildOptionFilter(projection, skus, counter, groupFilter))
            .ToArray();
 
        return (group.First().Group, options);
    }
 
    private static OptionFilter BuildOptionFilter(
        OptionProjection projection,
        IReadOnlyList<SkuProjection> skus,
        ProjectionCountBuilder counter,
        OptionProjectionFilter? groupFilter)
    {
        return new OptionFilter
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
        };
    }
}