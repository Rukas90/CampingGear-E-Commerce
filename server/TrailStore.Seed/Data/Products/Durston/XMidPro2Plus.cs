using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Products.Durston;

// ReSharper disable UnusedType.Global
public static class XMidPro2Plus
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "X-Mid Pro 2+",
        "durston-x-mid-pro-2-plus",
        brandId: Brands.Durston.Id,
        categoryId: Categories.Tents.Id,
        thumbnailUrl: "/products/durston-x-mid-pro-2-plus-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/durston-x-mid-pro-2-plus-1.webp",
                "/products/durston-x-mid-pro-2-plus-2.webp",
                "/products/durston-x-mid-pro-2-plus-3.webp",
                "/products/durston-x-mid-pro-2-plus-4.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "DRST-XMIDPRO2P-STD",
            920.00m,
            4,
            [])
    ];
}