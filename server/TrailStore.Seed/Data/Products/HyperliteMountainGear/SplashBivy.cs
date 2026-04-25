using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.HyperliteMountainGear;

// ReSharper disable UnusedType.Global

public sealed class SplashBivy
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Splash Bivy",
        slug:         "hyperlite-mountain-gear-splash-bivy",
        brandId:      Brands.HyperliteMountainGear.Id,
        categoryId:   Categories.BivysLiners.Id,
        thumbnailUrl: "products/hyperlite-mountain-gear-splash-bivy-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["products/hyperlite-mountain-gear-splash-bivy-1.webp",
                        "products/hyperlite-mountain-gear-splash-bivy-2.webp",
                        "products/hyperlite-mountain-gear-splash-bivy-3.webp",
                        "products/hyperlite-mountain-gear-splash-bivy-4.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "HMG-SPLSHBIVY-REG",
            price: 292.00m,
            stock: 5,
            options: [SizeOption.Regular]),

        Sku.Create(
            productId: Product.Id,
            code: "HMG-SPLSHBIVY-LG",
            price: 292.00m,
            stock: 3,
            options: [SizeOption.Large]),
    ];
}