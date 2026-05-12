using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.HyperliteMountainGear;

// ReSharper disable UnusedType.Global
public static class SplashBivy
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Splash Bivy",
        "hyperlite-mountain-gear-splash-bivy",
        brandId: Brands.HyperliteMountainGear.Id,
        categoryId: Categories.BivysLiners.Id,
        thumbnailUrl: "/products/hyperlite-mountain-gear-splash-bivy-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/hyperlite-mountain-gear-splash-bivy-1.webp",
                "/products/hyperlite-mountain-gear-splash-bivy-2.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "HMG-SPLSHBIVY-REG",
            292.00m,
            5,
            [SizeOption.Regular]),

        Sku.Create(
            Product.Id,
            "HMG-SPLSHBIVY-LG",
            292.00m,
            3,
            [SizeOption.Large])
    ];
}