using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.HyperliteMountainGear;

// ReSharper disable UnusedType.Global
public static class BugBivy
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Bug Bivy",
        "hyperlite-mountain-gear-bug-bivy",
        brandId: Brands.HyperliteMountainGear.Id,
        categoryId: Categories.BivysLiners.Id,
        thumbnailUrl: "/products/hyperlite-mountain-gear-bug-bivy-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/hyperlite-mountain-gear-bug-bivy-1.webp",
                "/products/hyperlite-mountain-gear-bug-bivy-2.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "HMG-BUGBIVY-REG",
            272.00m,
            6,
            [SizeOption.Regular]),

        Sku.Create(
            Product.Id,
            "HMG-BUGBIVY-LG",
            272.00m,
            4,
            [SizeOption.Large])
    ];
}