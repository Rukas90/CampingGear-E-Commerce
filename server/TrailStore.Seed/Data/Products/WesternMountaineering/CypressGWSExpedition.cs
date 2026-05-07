using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.WesternMountaineering;

// ReSharper disable UnusedType.Global

public static class CypressGWSExpedition
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Cypress GWS Expedition",
        slug:         "western-mountaineering-cypress-gws",
        brandId:      Brands.WesternMountaineering.Id,
        categoryId:   Categories.SleepingBags.Id,
        thumbnailUrl: "/products/western-mountaineering-cypress-gws-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "WM-CYPRESS-GWS-180LFT",
            price: 1860.00m,
            stock: 9,
            options: [LengthOption.Cm180, ZipOption.Left]),
        
        Sku.Create(
            productId: Product.Id,
            code: "WM-CYPRESS-GWS-180RHT",
            price: 1860.00m,
            stock: 8,
            options: [LengthOption.Cm180, ZipOption.Right]),
    ];
}