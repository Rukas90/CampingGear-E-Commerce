using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Durston;

// ReSharper disable UnusedType.Global
public static class XMidPro2
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "X-Mid Pro 2",
        "durston-x-mid-pro-2",
        brandId: Brands.Durston.Id,
        categoryId: Categories.Tents.Id,
        thumbnailUrl: "/products/durston-x-mid-pro-2-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/durston-x-mid-pro-2-1.webp",
                "/products/durston-x-mid-pro-2-2.webp",
                "/products/durston-x-mid-pro-2-3.webp",
                "/products/durston-x-mid-pro-2-4.webp",
                "/products/durston-x-mid-pro-2-5.webp",
                "/products/durston-x-mid-pro-2-6.webp",
                "/products/durston-x-mid-pro-2-7.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "DRST-XMIDPRO2-WVN",
            901.00m,
            5,
            [FloorOption.Woven]),

        Sku.Create(
            Product.Id,
            "DRST-XMIDPRO2-DYN",
            1010.00m,
            1,
            [FloorOption.Dyneema])
    ];
}