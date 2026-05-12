using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Thermarest;

// ReSharper disable UnusedType.Global
public static class NeoAirXTherm_MAX
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "NeoAir XTherm NXT MAX",
        "thermarest-neoair-xtherm-max",
        brandId: Brands.Thermarest.Id,
        categoryId: Categories.SleepingMats.Id,
        thumbnailUrl: "/products/thermarest-neoair-xtherm-max-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/thermarest-neoair-xtherm-max-1.webp",
                "/products/thermarest-neoair-xtherm-max-2.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "TREST-NEOAIR-XTHERM-MAX-LRG",
            28.00m,
            1,
            [HeightOption.Tall, WidthOption.Wide]),

        Sku.Create(
            Product.Id,
            "TREST-NEOAIR-XTHERM-MAX-REGWIDE",
            28.00m,
            0,
            [HeightOption.Regular, WidthOption.Wide])
    ];
}