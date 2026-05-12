using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Cumulus;

// ReSharper disable UnusedType.Global
public static class Teneqa700
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Teneqa 700",
        "cumulus-teneqa-700",
        brandId: Brands.Cumulus.Id,
        categoryId: Categories.SleepingBags.Id,
        thumbnailUrl: "/products/cumulus-teneqa-700-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ["/products/cumulus-teneqa-700-1.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "CLMS-TENEQA700-LFT",
            515.00m,
            0,
            [ZipOption.Left]),

        Sku.Create(
            Product.Id,
            "CLMS-TENEQA700-RGT",
            515.00m,
            0,
            [ZipOption.Right])
    ];
}