using System.Linq.Expressions;
using TrailStore.Api.Carts.Dto;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Api.Carts.Mapping;

public static class CartMappingSelectors
{
    public static Expression<Func<CartItem, CartItemDto>> ToItemDto()
    {
        return item => new CartItemDto
        {
            Code         = item.Sku.Code,
            Quantity     = item.Quantity,
            BrandName    = item.Sku.Product.Brand.Name,
            BrandSlug    = item.Sku.Product.Brand.Slug,
            ProductName  = item.Sku.Product.Name,
            ProductSlug  = item.Sku.Product.Slug,
            UnitPrice    = item.Sku.UnitPrice,
            Stock        = item.Sku.Stock,
            ThumbnailUrl = item.Sku.Product.ThumbnailUrl ?? "",
            Options      = item.Sku.Options.Select(option => new CartItemOptionDto 
                { GroupName = option.OptionGroup.Name, ValueName = option.Name}).ToArray()
        };
    }
}