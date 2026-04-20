using TrailStore.Domain.Filters;
using TrailStore.Domain.Models;
using TrailStore.Infrastructure.Skus;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Filters;

public interface IFiltersService
{
    Task<CatalogFilters> GetFilters(Specification<Sku> specification);
}
public class FiltersService(ISkuRepository skuRepository) : IFiltersService
{
    public async Task<CatalogFilters> GetFilters(Specification<Sku> specification)
    {
        var skus = await skuRepository.ListAllAsync(specification, s => new
        {
            s.UnitPrice,
            s.Stock,
            Brand    = new { s.Product.Brand.Name,     s.Product.Brand.Slug,     s.Product.BrandId    },
            Category = new { s.Product.Category.Name,  s.Product.Category.Slug,  s.Product.CategoryId },
            Options  = s.Options.Select(o => new
            {
                o.Id, o.Name, o.Slug, o.PreviewType, o.PreviewValue,
                Group = new { o.OptionGroup.Name, o.OptionGroup.Slug, o.OptionGroup.SortOrder }
            })
        });

        if (skus.Count <= 0)
        {
            return CatalogFilters.None;
        }
        return new CatalogFilters
        {
            Brands = skus.DistinctBy(s => s.Brand.BrandId)
                .Select(s => new FilterValue { Name = s.Brand.Name, Slug = s.Brand.Slug })
                .ToArray(),

            Categories = skus.DistinctBy(s => s.Category.CategoryId)
                .Select(s => new FilterValue { Name = s.Category.Name, Slug = s.Category.Slug })
                .ToArray(),

            Options = skus.SelectMany(s => s.Options)
                .DistinctBy(o => o.Id)
                .GroupBy(o => o.Group)
                .Select(g => new OptionGroupFilter
                {
                    Name      = g.Key.Name,
                    Slug      = g.Key.Slug,
                    SortOrder = g.Key.SortOrder,
                    Options   = g.Select(o => new OptionFilter
                    {
                        Name         = o.Name,
                        Slug         = o.Slug,
                        PreviewType  = o.PreviewType,
                        PreviewValue = o.PreviewValue
                    }).ToArray()
                })
                .ToArray(),

            MinPrice   = skus.Min(s => s.UnitPrice),
            MaxPrice   = skus.Max(s => s.UnitPrice),
            InStock    = skus.Count(s => s.Stock > 0),
            OutOfStock = skus.Count(s => s.Stock <= 0)
        };
    }
}