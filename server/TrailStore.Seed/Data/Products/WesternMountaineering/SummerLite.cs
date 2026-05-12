using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.WesternMountaineering;

// ReSharper disable UnusedType.Global
public static class SummerLite
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "SummerLite",
        "western-mountaineering-summer-lite",
        brandId: Brands.WesternMountaineering.Id,
        categoryId: Categories.SleepingBags.Id,
        thumbnailUrl: "/products/western-mountaineering-summer-lite-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/western-mountaineering-summer-lite-1.webp",
                "/products/western-mountaineering-summer-lite-2.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "WM-SUMMERLITE-165LFT",
            560.00m,
            5,
            [LengthOption.Cm165, ZipOption.Left]),

        Sku.Create(
            Product.Id,
            "WM-SUMMERLITE-165RHT",
            560.00m,
            6,
            [LengthOption.Cm165, ZipOption.Right]),

        Sku.Create(
            Product.Id,
            "WM-SUMMERLITE-180LFT",
            580.00m,
            2,
            [LengthOption.Cm180, ZipOption.Left]),

        Sku.Create(
            Product.Id,
            "WM-SUMMERLITE-180RHT",
            580.00m,
            4,
            [LengthOption.Cm180, ZipOption.Right]),

        Sku.Create(
            Product.Id,
            "WM-SUMMERLITE-200LFT",
            610.00m,
            4,
            [LengthOption.Cm200, ZipOption.Left]),

        Sku.Create(
            Product.Id,
            "WM-SUMMERLITE-200RHT",
            610.00m,
            3,
            [LengthOption.Cm200, ZipOption.Right])
    ];
}