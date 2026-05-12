using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.WesternMountaineering;

// ReSharper disable UnusedType.Global
public static class CypressGWSExpedition
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Cypress GWS Expedition",
        "western-mountaineering-cypress-gws",
        brandId: Brands.WesternMountaineering.Id,
        categoryId: Categories.SleepingBags.Id,
        thumbnailUrl: "/products/western-mountaineering-cypress-gws-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/western-mountaineering-cypress-gws-1.webp",
                "/products/western-mountaineering-cypress-gws-2.webp",
                "/products/western-mountaineering-cypress-gws-3.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "WM-CYPRESS-GWS-180LFT",
            1860.00m,
            9,
            [LengthOption.Cm180, ZipOption.Left]),

        Sku.Create(
            Product.Id,
            "WM-CYPRESS-GWS-180RHT",
            1860.00m,
            8,
            [LengthOption.Cm180, ZipOption.Right])
    ];
}