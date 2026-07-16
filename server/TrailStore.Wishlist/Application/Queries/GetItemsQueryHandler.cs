using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Wishlist.Application.Abstractions;
using TrailStore.Wishlist.Application.Results;

namespace TrailStore.Wishlist.Application.Queries;

[AppService<GetItemsQueryHandler>]
public sealed class GetItemsQueryHandler(
    IWishlistRepository repository, ISkuService skuService) : IQueryHandler<GetItemsQuery, WishlistItemResult[]>
{
    public async Task<Result<WishlistItemResult[]>> Handle(GetItemsQuery query, CancellationToken ct)
    {
        var wishlist = await repository.FindByUserId(query.UserId, ct);

        if (wishlist is null || wishlist.Items.Count <= 0)
        {
            return Array.Empty<WishlistItemResult>();
        }
        
        var skus = await skuService.GetSkusFromIds(wishlist.GetSkus(), ct);
        
        return skus.Select(sku => new WishlistItemResult
        {
            SkuId = sku.Id,
            BrandName = sku.Brand.Name,
            ProductName = sku.Product.Name,
            ProductSlug = sku.Product.Slug,
            SkuCode = sku.Code,
            UnitPrice = sku.UnitPrice,
            VariantLine = sku.VariantLine,
            ThumbnailUrl = sku.ThumbnailUrl
            
        }).ToArray();
    }
}