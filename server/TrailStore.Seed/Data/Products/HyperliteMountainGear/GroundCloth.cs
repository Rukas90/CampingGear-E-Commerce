using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Products.HyperliteMountainGear;

// ReSharper disable UnusedType.Global
public static class GroundCloth
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Ground Cloth",
        "hyperlite-mountain-gear-ground-cloth",
        brandId: Brands.HyperliteMountainGear.Id,
        categoryId: Categories.Accessories.Id,
        description:
        """
        The Hyperlite Mountain Gear Ground Cloth is a minimalist DCF groundsheet for backpackers who want reliable moisture and puncture protection without meaningful added weight.

        Made from DCF8 Dyneema Composite Fabric with DCF11-reinforced corners, it's fully waterproof and sized at 244cm x 132cm (96 x 52 in) — large enough for one person with all their gear. Six half-inch binding tie-out points keep it anchored in wind. Total weight is just 107g (3.77 oz). Packs into an included DCF stuff sack.

        Works as a standalone cowboy camping layer, a footprint under floorless shelters like the HMG UltaMid or Flat Tarp, or simply as a clean surface to organize gear at camp.
        """,
        thumbnailUrl: "/products/hyperlite-mountain-gear-ground-cloth-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/hyperlite-mountain-gear-ground-cloth-1.webp",
                "/products/hyperlite-mountain-gear-ground-cloth-2.webp",
                "/products/hyperlite-mountain-gear-ground-cloth-3.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "HMG-GRNDCLTH-STD",
            231.00m,
            0,
            [])
    ];
}