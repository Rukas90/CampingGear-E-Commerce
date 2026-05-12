using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global
public static class PlexSoloLite
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Plex Solo Lite",
        "zpacks-plex-solo-lite",
        brandId: Brands.Zpacks.Id,
        categoryId: Categories.Tents.Id,
        description:
        "Zpacks Plex Solo Lite Tent - is easily the lightest full-featured one-person tent in the world. Designed for adventurers who value weight but aren't willing to sacrifice performance or comfort, the Plex Solo is the ultimate shelter for weight-conscious hikers looking to redefine boundaries and push limits. The Plex Solo Lite shares the same dimensions as standard Plex Solo Tent. It utilizes proven .55 oz/sqyd Dyneema Composite Fabric canopy combined with a .75 oz/sqyd DCF floor material which is 25% lighter and packs down smaller relative to our standard tent floors. It comes preconfigured with bright yellow 1.3 mm Z-Line guy-lines which saves weight compared to the 2 mm guy lines on Zpacks standard tents.",
        thumbnailUrl: "/products/zpacks-plex-solo-lite-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ColorOption.Blue.Id,
            ["/products/zpacks-plex-solo-lite-blu.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.Olive.Id,
            ["/products/zpacks-plex-solo-lite-olv.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.SpruceGreen.Id,
            ["/products/zpacks-plex-solo-lite-sgrn.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "ZP-PLXSLLT-BLU",
            809.00m,
            1,
            [ColorOption.Blue]),

        Sku.Create(
            Product.Id,
            "ZP-PLXSLLT-OLV",
            809.00m,
            0,
            [ColorOption.Olive]),

        Sku.Create(
            Product.Id,
            "ZP-PLXSLLT-SGRN",
            809.00m,
            1,
            [ColorOption.SpruceGreen])
    ];
}