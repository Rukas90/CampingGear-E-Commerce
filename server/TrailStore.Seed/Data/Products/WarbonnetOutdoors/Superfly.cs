using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.WarbonnetOutdoors;

// ReSharper disable UnusedType.Global
public static class Superfly
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Superfly",
        "warbonnet-outdoors-superfly",
        brandId: Brands.WarbonnetOutdoors.Id,
        categoryId: Categories.Tents.Id,
        description:
        "Warbonnet Outdoors Superfly 11Ft - is a large all-season tarp that provides excellent coverage at an affordable price. The Superfly is not only largest but most popular tarp from Warbonnet. Pairs well any of their hammock models. Great for cold weather use as \"Winter\" tarp or folks who want one tarp for all conditions and seasons as \"All-Season\" tarp. The doors of the Superfly are not removable, but are built-in to the shape of the tarp and can be folded underneath when not needed. The versatility, expansive coverage and convenient built-in doors make the Superfly a great tarp for any of Warbonnet's hammock models.",
        thumbnailUrl: "/products/warbonnet-outdoors-superfly-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ColorOption.Brown.Id,
            ["/products/warbonnet-outdoors-superfly-brn.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.ShadowPineCamo.Id,
            ["/products/warbonnet-outdoors-superfly-spcmo.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.LeafyWoodsCamo.Id,
            ["/products/warbonnet-outdoors-superfly-lwcmo.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.SnowDayCamo.Id,
            ["/products/warbonnet-outdoors-superfly-sdcmo.webp"]),

        ProductImage.Create(
            Product.Id,
            [
                "/products/warbonnet-outdoors-superfly-1.webp",
                "/products/warbonnet-outdoors-superfly-2.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "WBO-SFLY-BRN",
            259.00m,
            6,
            [ColorOption.Brown]),

        Sku.Create(
            Product.Id,
            "WBO-SFLY-SPCMO",
            305.00m,
            0,
            [ColorOption.ShadowPineCamo]),

        Sku.Create(
            Product.Id,
            "WBO-SFLY-LWCMO",
            305.00m,
            8,
            [ColorOption.LeafyWoodsCamo]),

        Sku.Create(
            Product.Id,
            "WBO-SFLY-SDCMO",
            305.00m,
            2,
            [ColorOption.SnowDayCamo])
    ];
}