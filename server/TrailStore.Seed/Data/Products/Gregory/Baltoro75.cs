using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Gregory;

// ReSharper disable UnusedType.Global

public static class Baltoro75
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Baltoro 75",
        slug:         "gregory-baltoro-75",
        brandId:      Brands.Gregory.Id,
        categoryId:   Categories.Backpacks.Id,
        thumbnailUrl: "/products/gregory-baltoro-75-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "GREG-BALTORO-75-BLK",
            price: 400.00m,
            stock: 3,
            options: [ColorOption.Black]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GREG-BALTORO-75-TRRGRN",
            price: 400.00m,
            stock: 2,
            options: [ColorOption.TerrainGreen]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GREG-BALTORO-75-STLBLU",
            price: 400.00m,
            stock: 6,
            options: [ColorOption.StellarBlue]),
    ];
}