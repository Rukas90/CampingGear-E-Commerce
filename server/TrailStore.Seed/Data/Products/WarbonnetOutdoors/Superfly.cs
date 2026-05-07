using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.WarbonnetOutdoors;

// ReSharper disable UnusedType.Global

public sealed class Superfly
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Superfly",
        slug:         "warbonnet-outdoors-superfly",
        brandId:      Brands.WarbonnetOutdoors.Id,
        categoryId:   Categories.Tents.Id,
        description:  "Warbonnet Outdoors Superfly 11Ft - is a large all-season tarp that provides excellent coverage at an affordable price. The Superfly is not only largest but most popular tarp from Warbonnet. Pairs well any of their hammock models. Great for cold weather use as \"Winter\" tarp or folks who want one tarp for all conditions and seasons as \"All-Season\" tarp. The doors of the Superfly are not removable, but are built-in to the shape of the tarp and can be folded underneath when not needed. The versatility, expansive coverage and convenient built-in doors make the Superfly a great tarp for any of Warbonnet's hammock models.",
        thumbnailUrl: "/products/warbonnet-outdoors-superfly-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.BushwackCamo.Id,
            urls:      ["/products/warbonnet-outdoors-superfly-bwcmo.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.ShadowPineCamo.Id,
            urls:      ["/products/warbonnet-outdoors-superfly-spcmo.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.DarkFoliageGreen.Id,
            urls:      ["/products/warbonnet-outdoors-superfly-dfgrn.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.SnowDayCamo.Id,
            urls:      ["/products/warbonnet-outdoors-superfly-sdcmo.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            urls:      ["/products/warbonnet-outdoors-superfly-1.webp",
                        "/products/warbonnet-outdoors-superfly-2.webp",
                        "/products/warbonnet-outdoors-superfly-3.webp",
                        "/products/warbonnet-outdoors-superfly-4.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "WBO-SFLY-BWCMO",
            price: 305.00m,
            stock: 6,
            options: [ColorOption.BushwackCamo]),

        Sku.Create(
            productId: Product.Id,
            code: "WBO-SFLY-SPCMO",
            price: 305.00m,
            stock: 0,
            options: [ColorOption.ShadowPineCamo]),

        Sku.Create(
            productId: Product.Id,
            code: "WBO-SFLY-DFGRN",
            price: 259.00m,
            stock: 8,
            options: [ColorOption.DarkFoliageGreen]),

        Sku.Create(
            productId: Product.Id,
            code: "WBO-SFLY-SDCMO",
            price: 305.00m,
            stock: 2,
            options: [ColorOption.SnowDayCamo]),
    ];
}