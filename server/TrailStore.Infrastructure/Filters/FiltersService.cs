using TrailStore.Domain.Filters.Interfaces;
using TrailStore.Domain.Filters.Models;
using TrailStore.Domain.Filters.Specifications;
using TrailStore.Domain.Skus.Interfaces;
using TrailStore.Infrastructure.Filters.Builder;
using TrailStore.Infrastructure.Filters.Projections;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Filters;

[AppService<IFiltersService>]
public sealed class FiltersService(ISkuRepository skuRepository) : IFiltersService
{
    public async Task<CatalogFilters> GetFilters(FiltersQuery query, CancellationToken ct)
    {
        var skus = await GetSkuProjections(query, ct);

        if (skus.Count <= 0 || ct.IsCancellationRequested) return CatalogFilters.None;

        return CatalogBuilder.Build(skus, query);
    }

    private async Task<IReadOnlyList<SkuProjection>> GetSkuProjections(FiltersQuery query, CancellationToken ct)
    {
        var specification = FiltersSpecificationBuilder.FromQuery(query);

        return await skuRepository.ListAllAsync(specification, sku => new SkuProjection(
            sku.ProductId, sku.UnitPrice, sku.Stock,
            new BrandProjection(sku.Product.BrandId, sku.Product.Brand.Name, sku.Product.Brand.Slug),
            new CategoryProjection(sku.Product.CategoryId, sku.Product.Category.Name, sku.Product.Category.Slug),
            sku.Options.Select(o => new OptionProjection(
                o.Name, o.Slug, o.SortOrder, o.PreviewType, o.PreviewValue,
                new OptionGroupProjection(o.OptionGroup.Name, o.OptionGroup.Slug, o.OptionGroup.SortOrder)
            ))
        ), ct);
    }
}