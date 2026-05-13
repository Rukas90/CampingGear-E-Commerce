using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global
public static class AltaplexClassic
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Altaplex Classic",
        "zpacks-altaplex-classic",
        brandId: Brands.Zpacks.Id,
        categoryId: Categories.Tents.Id,
        description:
        """
        The Zpacks Altaplex Classic is a single-wall, trekking pole shelter built specifically for taller backpackers — comfortably fitting hikers up to 6'6" (198cm) with a peak height of 142–147cm (56–58 in).

        Constructed from .75 oz/sqyd Dyneema Composite Fabric for a higher tear strength than the standard .55 oz/sqyd canopy, with a 20cm (8 in) tall bathtub floor and 2.3m² (25 ft²) of interior floor space. Pitches with a single trekking pole and packs down to just 11.5cm x 28cm (4.5 x 11 in) rolled tight. Storm doors open and close independently with no zippers — just metal hooks — giving you flexible ventilation without the long-term failure risk.

        A well-rounded shelter for thru-hikers who need serious interior room without stepping up in weight.
        """,
        thumbnailUrl: "/products/zpacks-altaplex-classic-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/zpacks-altaplex-classic-1.webp",
                "/products/zpacks-altaplex-classic-2.webp",
                "/products/zpacks-altaplex-classic-3.webp",
                "/products/zpacks-altaplex-classic-4.webp",
                "/products/zpacks-altaplex-classic-5.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "ZP-ALTPLXCLS-STD",
            883.00m,
            5,
            [])
    ];
}