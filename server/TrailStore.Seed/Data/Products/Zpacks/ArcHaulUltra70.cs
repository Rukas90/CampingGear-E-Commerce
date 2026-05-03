using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global

public sealed class ArcHaulUltra70
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Arc Haul Ultra 70",
        slug:         "zpacks-arc-haul-ultra-70",
        brandId:      Brands.Zpacks.Id,
        categoryId:   Categories.Backpacks.Id,
        thumbnailUrl: "products/zpacks-arc-haul-ultra-70-thumb.webp");

    [SeededEntity] 
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id, 
            optionId:  ColorOption.DuskBlue.Id, 
            urls:      ["products/zpacks-arc-haul-ultra-70-dskblu.webp"]),
        
        ProductImage.Create(
            productId: Product.Id, 
            optionId:  ColorOption.JetBlack.Id, 
            urls:      ["products/zpacks-arc-haul-ultra-70-jtblk.webp"]),
        
        ProductImage.Create(
            productId: Product.Id, 
            optionId:  ColorOption.StormGray.Id, 
            urls:      ["products/zpacks-arc-haul-ultra-70-stmgry.webp"])
    ];
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "ZP-ARCHAUL70-DSKBLU-SH",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.DuskBlue, TorsoHeightOption.Short]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZP-ARCHAUL70-JTBLK-SH",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.JetBlack, TorsoHeightOption.Short]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZP-ARCHAUL70-STMGRY-SH",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.StormGray, TorsoHeightOption.Short]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZP-ARCHAUL70-DSKBLU-MD",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.DuskBlue, TorsoHeightOption.Medium]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZP-ARCHAUL70-JTBLK-MD",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.JetBlack, TorsoHeightOption.Medium]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZP-ARCHAUL70-STMGRY-MD",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.StormGray, TorsoHeightOption.Medium]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZP-ARCHAUL70-DSKBLU-TL",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.DuskBlue, TorsoHeightOption.Tall]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZP-ARCHAUL70-JTBLK-TL",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.JetBlack, TorsoHeightOption.Tall]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZP-ARCHAUL70-STMGRY-TL",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.StormGray, TorsoHeightOption.Tall])
    ];
}