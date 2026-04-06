using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Thermarest;

public sealed class NeoAir_XLite
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:       "NeoAir® XLite™ NXT",
        slug:       "thermarest-neoair-xlite",
        brandId:    Brands.Thermarest.Id,
        categoryId: Categories.SleepingMats.Id);
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "TREST-NEOAIR-XLITE-REG",
            price: 250.00m,
            stock: 11,
            options: [SizeOption.Regular]),
        
        Sku.Create(
            productId: Product.Id,
            code: "TREST-NEOAIR-XLITE-LRG",
            price: 294.00m,
            stock: 6,
            options: [SizeOption.Large]),
        
        Sku.Create(
            productId: Product.Id,
            code: "TREST-NEOAIR-XLITE-REGWIDE",
            price: 277.00m,
            stock: 4,
            options: [SizeOption.RegularWide]),
        
        Sku.Create(
            productId: Product.Id,
            code: "TREST-NEOAIR-XLITE-SHTREG",
            price: 250.00m,
            stock: 0,
            options: [SizeOption.ShortRegular])
    ];
}