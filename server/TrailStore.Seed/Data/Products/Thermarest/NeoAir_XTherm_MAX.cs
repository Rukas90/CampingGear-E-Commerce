using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Thermarest;

public sealed class NeoAir_XTherm_MAX
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:       "NeoAir XTherm NXT MAX",
        slug:       "thermarest-neoair-xtherm-max",
        brandId:    Brands.Thermarest.Id,
        categoryId: Categories.SleepingMats.Id);
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "TREST-NEOAIR-XTHERM-MAX-LRG",
            price: 28.00m,
            stock: 1,
            options: [SizeOption.Large]),

        Sku.Create(
            productId: Product.Id,
            code: "TREST-NEOAIR-XTHERM-MAX-REGWIDE",
            price: 28.00m,
            stock: 0,
            options: [SizeOption.RegularWide])
    ];
}