using TrailStore.Basket.Application.Results;
using TrailStore.Basket.Domain.Carts;
using TrailStore.Catalog.Contracts.Skus;

namespace TrailStore.Basket.Application.Queries.GetCart;

public static class CartMapping
{
    public static List<CartItemResult> ToResultItems(this IReadOnlyList<CartItem> items, IEnumerable<SkuSnapshot> skus)
        => items
            .Select(item => (item, sku: skus.FirstOrDefault(sku => sku.Id == item.SkuId)))
            .Where(x => x.sku != null)
            .Select(x => (x.item, sku: x.sku!)) 
            .Select(x => new CartItemResult
            {
                Id = x.item.Id,
                Quantity = x.item.Quantity,
                ProductName = x.sku.Product.Name,
                ProductSlug = x.sku.Product.Slug,
                BrandName = x.sku.Brand.Name,
                BrandSlug = x.sku.Brand.Slug,
                UnitPrice = x.sku.UnitPrice,
                Stock = x.sku.Stock,
                ThumbnailUrl = x.sku.ThumbnailUrl,
                Options = x.sku!.Options
                    .Select(snapshot => new ItemOptionResult(snapshot.Group.Name, snapshot.Value.Name))
                    .ToArray()
            }).ToList();
}