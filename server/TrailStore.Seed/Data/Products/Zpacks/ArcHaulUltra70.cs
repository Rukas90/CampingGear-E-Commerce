using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global

public sealed class ArcHaulUltra70
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:       "Arc Haul Ultra 70",
        slug:       "zpacks-arc-haul-ultra-70",
        brandId:    Brands.Zpacks.Id,
        categoryId: Categories.Backpacks.Id);

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "ZPK-ARCHAUL70-DSKBLU-SH",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.DuskBlue, TorsoHeightOption.Short]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZPK-ARCHAUL70-JTBLK-SH",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.JetBlack, TorsoHeightOption.Short]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZPK-ARCHAUL70-STMGRY-SH",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.StormGray, TorsoHeightOption.Short]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZPK-ARCHAUL70-DSKBLU-MD",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.DuskBlue, TorsoHeightOption.Medium]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZPK-ARCHAUL70-JTBLK-MD",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.JetBlack, TorsoHeightOption.Medium]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZPK-ARCHAUL70-STMGRY-MD",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.StormGray, TorsoHeightOption.Medium]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZPK-ARCHAUL70-DSKBLU-TL",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.DuskBlue, TorsoHeightOption.Tall]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZPK-ARCHAUL70-JTBLK-TL",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.JetBlack, TorsoHeightOption.Tall]),
        
        Sku.Create(
            productId: Product.Id,
            code: "ZPK-ARCHAUL70-STMGRY-TL",
            price: 531.00m,
            stock: 0,
            options: [ColorOption.StormGray, TorsoHeightOption.Tall])
    ];
}