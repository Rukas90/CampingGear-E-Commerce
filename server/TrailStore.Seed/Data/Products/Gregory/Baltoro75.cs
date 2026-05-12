using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Products.Gregory;

// ReSharper disable UnusedType.Global
public static class Baltoro75
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Baltoro 75",
        "gregory-baltoro-75",
        brandId: Brands.Gregory.Id,
        categoryId: Categories.Backpacks.Id,
        thumbnailUrl: "/products/gregory-baltoro-75-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/gregory-baltoro-75-1.webp",
                "/products/gregory-baltoro-75-2.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "GREG-BALTORO-75-STD",
            400.00m,
            3,
            [])
    ];
}