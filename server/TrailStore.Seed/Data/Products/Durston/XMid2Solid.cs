using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Products.Durston;

// ReSharper disable UnusedType.Global
public static class XMid2Solid
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "X-Mid 2 Solid",
        "durston-x-mid-2-solid",
        brandId: Brands.Durston.Id,
        categoryId: Categories.Tents.Id,
        thumbnailUrl: "/products/durston-x-mid-2-solid-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/durston-x-mid-2-solid-1.webp",
                "/products/durston-x-mid-2-solid-2.webp",
                "/products/durston-x-mid-2-solid-3.webp",
                "/products/durston-x-mid-2-solid-4.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "DRST-XMID2SLD-STD",
            440.00m,
            6,
            [])
    ];
}