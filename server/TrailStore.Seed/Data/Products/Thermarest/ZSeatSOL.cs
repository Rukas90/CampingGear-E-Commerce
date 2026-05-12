using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Thermarest;

// ReSharper disable UnusedType.Global
public static class ZSeatSOL
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Z Seat SOL",
        "thermarest-zseat-sol",
        brandId: Brands.Thermarest.Id,
        categoryId: Categories.SleepingMats.Id,
        thumbnailUrl: "/products/thermarest-zseat-sol-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ColorOption.Yellow.Id,
            [
                "/products/thermarest-zseat-sol-ylw-1.webp",
                "/products/thermarest-zseat-sol-ylw-2.webp"
            ]),

        ProductImage.Create(
            Product.Id,
            ColorOption.Blue.Id,
            [
                "/products/thermarest-zseat-sol-blu-1.webp",
                "/products/thermarest-zseat-sol-blu-2.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "TREST-ZSEAT-SOL-YLW",
            28.00m,
            8,
            [ColorOption.Yellow]),

        Sku.Create(
            Product.Id,
            "TREST-ZSEAT-SOL-BLU",
            28.00m,
            7,
            [ColorOption.Blue])
    ];
}