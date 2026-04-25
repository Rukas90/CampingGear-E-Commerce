using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Thermarest;

// ReSharper disable UnusedType.Global

public sealed class NeoAirXLite
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "NeoAir® XLite™ NXT",
        slug:         "thermarest-neoair-xlite",
        brandId:      Brands.Thermarest.Id,
        categoryId:   Categories.SleepingMats.Id,
        thumbnailUrl: "products/thermarest-neoair-xlite-thumb.webp");
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "TREST-NEOAIR-XLITE-REG",
            price: 250.00m,
            stock: 11,
            options: [HeightOption.Regular, WidthOption.Regular]),
        
        Sku.Create(
            productId: Product.Id,
            code: "TREST-NEOAIR-XLITE-LRG",
            price: 294.00m,
            stock: 6,
            options: [HeightOption.Tall, WidthOption.Wide]),
        
        Sku.Create(
            productId: Product.Id,
            code: "TREST-NEOAIR-XLITE-REGWIDE",
            price: 277.00m,
            stock: 4,
            options: [HeightOption.Regular, WidthOption.Wide]),
        
        Sku.Create(
            productId: Product.Id,
            code: "TREST-NEOAIR-XLITE-SHTREG",
            price: 250.00m,
            stock: 0,
            options: [HeightOption.Short, WidthOption.Regular])
    ];
}