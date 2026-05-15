using System.Linq.Expressions;
using TrailStore.Api.Carts.Dto;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Api.Carts.Mapping;

public static class CartMappingSelectors
{
    public static Expression<Func<Sku, CartSkusDto>> ToCartSkuDto()
    {
        return sku => new CartSkusDto
        {
            Code         = sku.Code,
            ProductName  = sku.Product.Name,
            ProductSlug  = sku.Product.Slug,
            UnitPrice    = sku.UnitPrice,
            Stock        = sku.Stock,
            ThumbnailUrl = sku.Product.ThumbnailUrl ?? "",
            Options      = sku.Options.Select(option => new CartSkuOptionDto 
                { GroupName = option.OptionGroup.Name, ValueName = option.Name}).ToArray()
        };
    }
}