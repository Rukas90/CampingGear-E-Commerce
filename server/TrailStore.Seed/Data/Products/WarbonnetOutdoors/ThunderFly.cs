using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.WarbonnetOutdoors;

// ReSharper disable UnusedType.Global

public static class ThunderFly
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "ThunderFly",
        slug:         "warbonnet-outdoors-thunderfly",
        brandId:      Brands.WarbonnetOutdoors.Id,
        categoryId:   Categories.Tents.Id,
        description:  "Warbonnet Outdoors ThunderFly 11Ft - is hex-style tarp with partial doors. Features the Warbonnets newest tarp designs. Being a slightly larger version of the lightweight Minifly, this tarp is built for those that want the simplicity and convenience of a standard hex tarp but with extra end-coverage when the weather gets nasty. If you're looking for something slightly lighter and smaller, check out MiniFly tarp model, it's a slightly downsized version of the ThunderFly and will save you a couple grams while still offering great coverage.",
        thumbnailUrl: "/products/warbonnet-outdoors-thunderfly-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.BushwackCamo.Id,
            urls:      ["/products/warbonnet-outdoors-thunderfly-bwcmo.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.ShadowPineCamo.Id,
            urls:      ["/products/warbonnet-outdoors-thunderfly-spcmo.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.DarkFoliageGreen.Id,
            urls:      ["/products/warbonnet-outdoors-thunderfly-dfgrn.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.SnowDayCamo.Id,
            urls:      ["/products/warbonnet-outdoors-thunderfly-sdcmo.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            urls:      ["/products/warbonnet-outdoors-thunderfly-1.webp",
                        "/products/warbonnet-outdoors-thunderfly-2.webp",
                        "/products/warbonnet-outdoors-thunderfly-3.webp",
                        "/products/warbonnet-outdoors-thunderfly-4.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "WBO-TFLY-BWCMO",
            price: 244.00m,
            stock: 5,
            options: [ColorOption.BushwackCamo]),

        Sku.Create(
            productId: Product.Id,
            code: "WBO-TFLY-SPCMO",
            price: 244.00m,
            stock: 4,
            options: [ColorOption.ShadowPineCamo]),

        Sku.Create(
            productId: Product.Id,
            code: "WBO-TFLY-DFGRN",
            price: 202.00m,
            stock: 6,
            options: [ColorOption.DarkFoliageGreen]),

        Sku.Create(
            productId: Product.Id,
            code: "WBO-TFLY-SDCMO",
            price: 248.00m,
            stock: 0,
            options: [ColorOption.SnowDayCamo]),
    ];
}