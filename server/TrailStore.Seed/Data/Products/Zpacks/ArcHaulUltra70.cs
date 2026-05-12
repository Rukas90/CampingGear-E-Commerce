using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global
public static class ArcHaulUltra70
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Arc Haul Ultra 70",
        "zpacks-arc-haul-ultra-70",
        brandId: Brands.Zpacks.Id,
        categoryId: Categories.Backpacks.Id,
        thumbnailUrl: "/products/zpacks-arc-haul-ultra-70-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ColorOption.DuskBlue.Id,
            ["/products/zpacks-arc-haul-ultra-70-dskblu.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.JetBlack.Id,
            ["/products/zpacks-arc-haul-ultra-70-jtblk.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.StormGray.Id,
            ["/products/zpacks-arc-haul-ultra-70-stmgry.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "ZP-ARCHAUL70-DSKBLU-SH",
            531.00m,
            0,
            [ColorOption.DuskBlue, TorsoHeightOption.Short]),

        Sku.Create(
            Product.Id,
            "ZP-ARCHAUL70-JTBLK-SH",
            531.00m,
            0,
            [ColorOption.JetBlack, TorsoHeightOption.Short]),

        Sku.Create(
            Product.Id,
            "ZP-ARCHAUL70-STMGRY-SH",
            531.00m,
            0,
            [ColorOption.StormGray, TorsoHeightOption.Short]),

        Sku.Create(
            Product.Id,
            "ZP-ARCHAUL70-DSKBLU-MD",
            531.00m,
            0,
            [ColorOption.DuskBlue, TorsoHeightOption.Medium]),

        Sku.Create(
            Product.Id,
            "ZP-ARCHAUL70-JTBLK-MD",
            531.00m,
            0,
            [ColorOption.JetBlack, TorsoHeightOption.Medium]),

        Sku.Create(
            Product.Id,
            "ZP-ARCHAUL70-STMGRY-MD",
            531.00m,
            0,
            [ColorOption.StormGray, TorsoHeightOption.Medium]),

        Sku.Create(
            Product.Id,
            "ZP-ARCHAUL70-DSKBLU-TL",
            531.00m,
            0,
            [ColorOption.DuskBlue, TorsoHeightOption.Tall]),

        Sku.Create(
            Product.Id,
            "ZP-ARCHAUL70-JTBLK-TL",
            531.00m,
            0,
            [ColorOption.JetBlack, TorsoHeightOption.Tall]),

        Sku.Create(
            Product.Id,
            "ZP-ARCHAUL70-STMGRY-TL",
            531.00m,
            0,
            [ColorOption.StormGray, TorsoHeightOption.Tall])
    ];
}