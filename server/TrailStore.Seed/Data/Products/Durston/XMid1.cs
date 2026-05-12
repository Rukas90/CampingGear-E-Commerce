using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Products.Durston;

// ReSharper disable UnusedType.Global
public static class XMid1
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "X-Mid 1",
        "durston-x-mid-1",
        brandId: Brands.Durston.Id,
        categoryId: Categories.Tents.Id,
        thumbnailUrl: "/products/durston-x-mid-1-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/durston-x-mid-1-1.webp",
                "/products/durston-x-mid-1-2.webp",
                "/products/durston-x-mid-1-3.webp",
                "/products/durston-x-mid-1-4.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "DRST-XMID1-STD",
            341.00m,
            0,
            [])
    ];
}