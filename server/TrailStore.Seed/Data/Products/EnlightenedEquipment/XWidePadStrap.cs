using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Products.EnlightenedEquipment;

// ReSharper disable UnusedType.Global
public static class XWidePadStrap
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "XWide Pad Strap",
        "enlightened-equipment-xwide-pad-strap",
        brandId: Brands.EnlightenedEquipment.Id,
        categoryId: Categories.Quilts.Id,
        thumbnailUrl: "/products/enlightened-equipment-xwide-pad-strap-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ["/products/enlightened-equipment-xwide-pad-strap-1.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "EE-XWPADSTRAP-STD",
            8.00m,
            25,
            [])
    ];
}