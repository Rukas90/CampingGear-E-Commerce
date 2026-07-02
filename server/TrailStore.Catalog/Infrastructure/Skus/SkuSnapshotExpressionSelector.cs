using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Catalog.Infrastructure.Skus;

internal static class SkuSnapshotExpressionSelector
{
    internal static SkuSnapshot ToSnapshot(this Sku sku) => new()
    {
        Id = Id<SkuRef>.From(sku.Id),
        Code = sku.Code,
        VariantLine = sku.VariantLine,
        Product = new EntityIdentifier(sku.Product.Name, sku.Product.Slug),
        Brand = new EntityIdentifier(sku.Product.Brand.Name, sku.Product.Brand.Slug),
        UnitPrice = sku.UnitPrice,
        Stock = sku.Stock,
        ThumbnailUrl = sku.Product.ThumbnailUrl,
        Options = sku.Options
            .Select(o => new SkuOptionSnapshot(
                new EntityIdentifier(o.OptionGroup.Name, o.OptionGroup.Slug),
                new EntityIdentifier(o.Name, o.Slug)))
            .ToArray()
    };
}