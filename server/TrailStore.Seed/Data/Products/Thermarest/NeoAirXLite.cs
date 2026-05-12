using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Thermarest;

// ReSharper disable UnusedType.Global
public static class NeoAirXLite
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "NeoAir XLite™ NXT",
        "thermarest-neoair-xlite",
        brandId: Brands.Thermarest.Id,
        categoryId: Categories.SleepingMats.Id,
        thumbnailUrl: "/products/thermarest-neoair-xlite-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/thermarest-neoair-xlite-1.webp",
                "/products/thermarest-neoair-xlite-2.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "TREST-NEOAIR-XLITE-REG",
            250.00m,
            11,
            [HeightOption.Regular, WidthOption.Regular]),

        Sku.Create(
            Product.Id,
            "TREST-NEOAIR-XLITE-LRG",
            294.00m,
            6,
            [HeightOption.Tall, WidthOption.Wide]),

        Sku.Create(
            Product.Id,
            "TREST-NEOAIR-XLITE-REGWIDE",
            277.00m,
            4,
            [HeightOption.Regular, WidthOption.Wide]),

        Sku.Create(
            Product.Id,
            "TREST-NEOAIR-XLITE-SHTREG",
            250.00m,
            0,
            [HeightOption.Short, WidthOption.Regular])
    ];
}