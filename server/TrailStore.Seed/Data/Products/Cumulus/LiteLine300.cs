using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Cumulus;

// ReSharper disable UnusedType.Global
public static class LiteLine300
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Lite Line 300",
        "cumulus-lite-line-300",
        brandId: Brands.Cumulus.Id,
        categoryId: Categories.SleepingBags.Id,
        thumbnailUrl: "/products/cumulus-lite-line-300-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/cumulus-lite-line-300-1.webp",
                "/products/cumulus-lite-line-300-2.webp",
                "/products/cumulus-lite-line-300-3.webp",
                "/products/cumulus-lite-line-300-4.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "CLMS-LITELINE300-LFT",
            316.00m,
            2,
            [ZipOption.Left]),

        Sku.Create(
            Product.Id,
            "CLMS-LITELINE300-RGT",
            316.00m,
            0,
            [ZipOption.Right])
    ];
}