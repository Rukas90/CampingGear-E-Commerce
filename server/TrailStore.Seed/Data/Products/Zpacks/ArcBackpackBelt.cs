using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global
public static class ArcBackpackBelt
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Arc Backpack Belt",
        "zpacks-arc-backpack-belt",
        brandId: Brands.Zpacks.Id,
        categoryId: Categories.CareProtection.Id,
        description:
        "Zpacks Arc backpacks feature a removable and interchangeable belt. This is a useful feature if you lose or gain weight, or if the pack is transferred to a different size person. If the belt wears out before the rest of the pack you could replace it.",
        thumbnailUrl: "/products/zpacks-arc-backpack-belt-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/zpacks-arc-backpack-belt-1.webp",
                "/products/zpacks-arc-backpack-belt-2.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "ZP-ARCBLT-SM",
            79.00m,
            8,
            [SizeOption.Small]),

        Sku.Create(
            Product.Id,
            "ZP-ARCBLT-MD",
            79.00m,
            11,
            [SizeOption.Medium]),

        Sku.Create(
            Product.Id,
            "ZP-ARCBLT-LG",
            79.00m,
            6,
            [SizeOption.Large]),

        Sku.Create(
            Product.Id,
            "ZP-ARCBLT-XL",
            79.00m,
            3,
            [SizeOption.XL])
    ];
}