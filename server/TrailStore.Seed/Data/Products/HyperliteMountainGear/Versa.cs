using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.HyperliteMountainGear;

public sealed class Versa
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:       "Versa",
        slug:       "hyperlite-mountain-gear-versa",
        brandId:    Brands.HyperliteMountain.Id,
        categoryId: Categories.StuffSacks.Id);

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "HMG-VERSA-BLK",
            price: 88.00m,
            stock: 11,
            options: [ColorOption.Black]),
        
        Sku.Create(
            productId: Product.Id,
            code: "HMG-VERSA-WHT",
            price: 88.00m,
            stock: 4,
            options: [ColorOption.White])
    ];
}