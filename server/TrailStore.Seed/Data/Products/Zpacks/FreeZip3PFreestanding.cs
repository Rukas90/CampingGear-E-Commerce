using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global
public static class FreeZip3PFreestanding
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Free Zip 3P Freestanding",
        "zpacks-free-zip-3p-freestanding",
        brandId: Brands.Zpacks.Id,
        categoryId: Categories.Tents.Id,
        description:
        """
        The Zpacks Free Zip 3P is a freestanding ultralight tent built for backpackers who need the versatility of a traditional dome tent without giving up the weight savings of Dyneema Composite Fabric.

        Four Easton Carbon 6.3 poles form a unique double-X frame that pitches fast, handles high winds well, and folds down to just 30.5cm (12 in) — small enough to pack horizontally in most backpacks. The canopy is constructed from .55 oz/sqyd DCF (available in blue and olive) or .75 oz/sqyd DCF (spruce green), with a total packaged weight of 1,025g (36.2 oz) including poles and guy lines.

        Fits three standard-width sleeping pads side by side, or two wide pads with room to spare. Pitches with zero stakes on calm nights, or can be anchored with up to 10 stakes in storm conditions. Works on bedrock, sand, snow, or any surface where staking isn't an option.

        The go-to choice for groups who want freestanding versatility and ultralight performance in one shelter.
        """,
        thumbnailUrl: "/products/zpacks-free-zip-3p-freestanding-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ColorOption.SpruceGreen.Id,
            ["/products/zpacks-free-zip-3p-freestanding-sgrn.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.Blue.Id,
            ["/products/zpacks-free-zip-3p-freestanding-blu.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.Olive.Id,
            ["/products/zpacks-free-zip-3p-freestanding-olv.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "ZP-FRZP3PFS-SGRN",
            1209.00m,
            3,
            [ColorOption.SpruceGreen]),

        Sku.Create(
            Product.Id,
            "ZP-FRZP3PFS-BLU",
            1209.00m,
            4,
            [ColorOption.Blue]),

        Sku.Create(
            Product.Id,
            "ZP-FRZP3PFS-OLV",
            1209.00m,
            2,
            [ColorOption.Olive])
    ];
}