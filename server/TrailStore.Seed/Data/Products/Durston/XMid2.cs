using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Products.Durston;

// ReSharper disable UnusedType.Global
public static class XMid2
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "X-Mid 2",
        "durston-x-mid-2",
        brandId: Brands.Durston.Id,
        categoryId: Categories.Tents.Id,
        thumbnailUrl: "/products/durston-x-mid-2-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/durston-x-mid-2-1.webp",
                "/products/durston-x-mid-2-2.webp",
                "/products/durston-x-mid-2-3.webp",
                "/products/durston-x-mid-2-4.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "DRST-XMID2-STD",
            391.00m,
            7,
            [])
    ];
}