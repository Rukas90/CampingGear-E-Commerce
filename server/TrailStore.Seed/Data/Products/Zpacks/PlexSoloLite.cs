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
        """
        The Zpacks Plex Solo Lite is the lightest full-featured solo tent on the market, built for ultralight backpackers who refuse to compromise on weather protection or livability.
        
        It features a .55 oz/sqyd Dyneema Composite Fabric canopy paired with a lighter .75 oz/sqyd DCF floor — 25% lighter than the standard Plex Solo floor — without giving up durability or waterproofness.
        
        Shares the same spacious geometry as the standard Plex Solo, with trekking pole setup and full coverage from the elements. Comes pre-rigged with 1.3 mm Z-Line guy-lines for additional weight savings over standard Zpacks tents.
        
        The go-to shelter for gram-counters tackling long trails, fast-and-light objectives, or any adventure where every ounce matters.
        """,
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