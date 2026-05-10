using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global

public static class PlexSoloLite
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Plex Solo Lite",
        slug:         "zpacks-plex-solo-lite",
        brandId:      Brands.Zpacks.Id,
        categoryId:   Categories.Tents.Id,
        description:  "Zpacks Plex Solo Lite Tent - is easily the lightest full-featured one-person tent in the world. Designed for adventurers who value weight but aren't willing to sacrifice performance or comfort, the Plex Solo is the ultimate shelter for weight-conscious hikers looking to redefine boundaries and push limits. The Plex Solo Lite shares the same dimensions as standard Plex Solo Tent. It utilizes proven .55 oz/sqyd Dyneema Composite Fabric canopy combined with a .75 oz/sqyd DCF floor material which is 25% lighter and packs down smaller relative to our standard tent floors. It comes preconfigured with bright yellow 1.3 mm Z-Line guy-lines which saves weight compared to the 2 mm guy lines on Zpacks standard tents.",
        thumbnailUrl: "/products/zpacks-plex-solo-lite-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.Blue.Id,
            urls:      ["/products/zpacks-plex-solo-lite-blu.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.Olive.Id,
            urls:      ["/products/zpacks-plex-solo-lite-olv.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.SpruceGreen.Id,
            urls:      ["/products/zpacks-plex-solo-lite-sgrn.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "ZP-PLXSLLT-BLU",
            price: 809.00m,
            stock: 1,
            options: [ColorOption.Blue]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-PLXSLLT-OLV",
            price: 809.00m,
            stock: 0,
            options: [ColorOption.Olive]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-PLXSLLT-SGRN",
            price: 809.00m,
            stock: 1,
            options: [ColorOption.SpruceGreen]),
    ];
}