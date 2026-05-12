using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Durston;

// ReSharper disable UnusedType.Global
public static class XMidPro1
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "X-Mid Pro 1",
        "durston-x-mid-pro-1",
        brandId: Brands.Durston.Id,
        categoryId: Categories.Tents.Id,
        thumbnailUrl: "/products/durston-x-mid-pro-1-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/durston-x-mid-pro-1-1.webp",
                "/products/durston-x-mid-pro-1-2.webp",
                "/products/durston-x-mid-pro-1-3.webp",
                "/products/durston-x-mid-pro-1-4.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "DRST-XMIDPRO1-WVN",
            768.00m,
            0,
            [FloorOption.Woven]),

        Sku.Create(
            Product.Id,
            "DRST-XMIDPRO1-DYN",
            886.00m,
            0,
            [FloorOption.Dyneema])
    ];
}