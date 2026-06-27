using System.Linq.Expressions;
using TrailStore.Catalog.Application.Queries.GetFilters.Builder;
using TrailStore.Catalog.Application.Queries.GetFilters.Projections;
using TrailStore.Catalog.Domain.Filters;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Catalog.Application.Queries.GetFilters;

[AppService<GetFiltersQueryHandler>]
public class GetFiltersQueryHandler(ISkuRepository skuRepository) : IQueryHandler<GetFiltersQuery, CatalogFilters>
{
    public async Task<Result<CatalogFilters>> Handle(GetFiltersQuery query, CancellationToken ct)
    {
        var specification = FiltersSpecificationBuilder.FromQuery(query);
        var skus = await skuRepository.ListAllAsync(specification, selector: SkuProjection, ct);
        
        if (skus.Count <= 0 || ct.IsCancellationRequested)
        {
            return CatalogFilters.None;
        }
        
        return CatalogBuilder.Build(skus, query);
    }
    
    public static readonly Expression<Func<Sku, SkuProjection>> SkuProjection = sku => new SkuProjection(
        sku.ProductId,
        sku.UnitPrice,
        sku.Stock - sku.Reserved,
        new BrandProjection(sku.Product.BrandId, sku.Product.Brand.Name, sku.Product.Brand.Slug),
        new CategoryProjection(sku.Product.CategoryId, sku.Product.Category.Name, sku.Product.Category.Slug),
        sku.Options.Select(o => new OptionProjection(
            o.Name, o.Slug, o.SortOrder, o.PreviewType, o.PreviewValue,
            new OptionGroupProjection(o.OptionGroup.Name, o.OptionGroup.Slug, o.OptionGroup.SortOrder)
        ))
    );
}