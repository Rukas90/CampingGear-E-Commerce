using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Products.HyperliteMountainGear;

// ReSharper disable UnusedType.Global
public static class UltaMid1
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "UltaMid 1",
        "hyperlite-mountain-gear-ultamid-1",
        brandId: Brands.HyperliteMountainGear.Id,
        categoryId: Categories.Tents.Id,
        description:
        "Hyperlite Mountain Gear UltaMid 1 - is a spacious, one-person, three-season shelter that offers unrivaled versatility and light weight for the essentials-only backcountry adventurer. Weighs less than 250g (9 oz) and packs down to the size of a water bottle, when it's rolled up. Covers an area of 3.7 m² (40 ft²t), and, because it's built with 100% waterproof Dyneema Composite Fabrics, offers outstanding protection against rain. \nCut and shaped with six perimeter tie-outs and requiring just one trekking pole for structure, it pitches fast and reliably every time you use it. Sets up with a single trekking pole at 135cm +/- 5cm.",
        thumbnailUrl: "/products/hyperlite-mountain-gear-ultamid-1-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/hyperlite-mountain-gear-ultamid-1-1.webp",
                "/products/hyperlite-mountain-gear-ultamid-1-2.webp",
                "/products/hyperlite-mountain-gear-ultamid-1-3.webp",
                "/products/hyperlite-mountain-gear-ultamid-1-4.webp",
                "/products/hyperlite-mountain-gear-ultamid-1-5.webp",
                "/products/hyperlite-mountain-gear-ultamid-1-6.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "HMG-ULTAMID1-STD",
            549.00m,
            7,
            [])
    ];
}