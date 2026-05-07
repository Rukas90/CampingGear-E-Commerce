using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.HyperliteMountainGear;

// ReSharper disable UnusedType.Global

public static class Versa
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Versa",
        slug:         "hyperlite-mountain-gear-versa",
        brandId:      Brands.HyperliteMountainGear.Id,
        categoryId:   Categories.StuffSacks.Id,
        thumbnailUrl: "/products/hyperlite-mountain-gear-versa-thumb.webp");

    [SeededEntity] 
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id, 
            optionId:  ColorOption.Black.Id, 
            urls:      ["/products/hyperlite-mountain-gear-versa-blk.webp"]),
        
        ProductImage.Create(
            productId: Product.Id, 
            optionId:  ColorOption.White.Id, 
            urls:      ["/products/hyperlite-mountain-gear-versa-wht.webp"])
    ];
    
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