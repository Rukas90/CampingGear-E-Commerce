using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.HyperliteMountainGear;

// ReSharper disable UnusedType.Global
public static class Versa
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Versa",
        "hyperlite-mountain-gear-versa",
        brandId: Brands.HyperliteMountainGear.Id,
        categoryId: Categories.StuffSacks.Id,
        thumbnailUrl: "/products/hyperlite-mountain-gear-versa-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ColorOption.Black.Id,
            ["/products/hyperlite-mountain-gear-versa-blk.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.White.Id,
            ["/products/hyperlite-mountain-gear-versa-wht.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "HMG-VERSA-BLK",
            88.00m,
            11,
            [ColorOption.Black]),

        Sku.Create(
            Product.Id,
            "HMG-VERSA-WHT",
            88.00m,
            4,
            [ColorOption.White])
    ];
}