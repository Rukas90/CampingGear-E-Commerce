using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.WesternMountaineering;

// ReSharper disable UnusedType.Global

public static class SummerLite
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "SummerLite",
        slug:         "western-mountaineering-summer-lite",
        brandId:      Brands.WesternMountaineering.Id,
        categoryId:   Categories.SleepingBags.Id,
        thumbnailUrl: "/products/western-mountaineering-summer-lite-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "WM-SUMMERLITE-165LFT",
            price: 560.00m,
            stock: 5,
            options: [LengthOption.Cm165, ZipOption.Left]),
        
        Sku.Create(
            productId: Product.Id,
            code: "WM-SUMMERLITE-165RHT",
            price: 560.00m,
            stock: 6,
            options: [LengthOption.Cm165, ZipOption.Right]),
        
        Sku.Create(
            productId: Product.Id,
            code: "WM-SUMMERLITE-180LFT",
            price: 580.00m,
            stock: 2,
            options: [LengthOption.Cm180, ZipOption.Left]),
        
        Sku.Create(
            productId: Product.Id,
            code: "WM-SUMMERLITE-180RHT",
            price: 580.00m,
            stock: 4,
            options: [LengthOption.Cm180, ZipOption.Right]),
        
        Sku.Create(
            productId: Product.Id,
            code: "WM-SUMMERLITE-200LFT",
            price: 610.00m,
            stock: 4,
            options: [LengthOption.Cm200, ZipOption.Left]),
        
        Sku.Create(
            productId: Product.Id,
            code: "WM-SUMMERLITE-200RHT",
            price: 610.00m,
            stock: 3,
            options: [LengthOption.Cm200, ZipOption.Right])
    ];
}