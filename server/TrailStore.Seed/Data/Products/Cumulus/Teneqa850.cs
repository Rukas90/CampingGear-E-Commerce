using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Cumulus;

// ReSharper disable UnusedType.Global
public static class Teneqa850
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Teneqa 850",
        "cumulus-teneqa-850",
        brandId: Brands.Cumulus.Id,
        categoryId: Categories.SleepingBags.Id,
        thumbnailUrl: "/products/cumulus-teneqa-850-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/cumulus-teneqa-850-1.webp",
                "/products/cumulus-teneqa-850-2.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "CLMS-TENEQA850-LFT",
            565.00m,
            0,
            [ZipOption.Left]),

        Sku.Create(
            Product.Id,
            "CLMS-TENEQA850-RGT",
            565.00m,
            0,
            [ZipOption.Right])
    ];
}