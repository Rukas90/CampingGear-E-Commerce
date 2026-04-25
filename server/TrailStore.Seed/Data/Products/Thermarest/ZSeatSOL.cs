using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Thermarest;

// ReSharper disable UnusedType.Global

public sealed class ZSeatSOL
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Z Seat SOL",
        slug:         "thermarest-zseat-sol",
        brandId:      Brands.Thermarest.Id,
        categoryId:   Categories.SleepingMats.Id,
        thumbnailUrl: "products/thermarest-zseat-sol-thumb.webp");

    [SeededEntity] 
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id, 
            optionId:  ColorOption.Yellow.Id, 
            urls:      ["products/thermarest-zseat-sol-ylw.webp"]),
        
        ProductImage.Create(
            productId: Product.Id, 
            optionId:  ColorOption.Blue.Id, 
            urls:      ["products/thermarest-zseat-sol-blu.webp"])
    ];
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "TREST-ZSEAT-SOL-YLW",
            price: 28.00m,
            stock: 8,
            options: [ColorOption.Yellow]),

        Sku.Create(
            productId: Product.Id,
            code: "TREST-ZSEAT-SOL-BLU",
            price: 28.00m,
            stock: 7,
            options: [ColorOption.Blue])
    ];
}