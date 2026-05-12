using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.WarbonnetOutdoors;

// ReSharper disable UnusedType.Global
public sealed class ThunderFly
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "ThunderFly",
        "warbonnet-outdoors-thunderfly",
        brandId: Brands.WarbonnetOutdoors.Id,
        categoryId: Categories.Tents.Id,
        description:
        "Warbonnet Outdoors ThunderFly 11Ft - is hex-style tarp with partial doors. Features the Warbonnets newest tarp designs. Being a slightly larger version of the lightweight Minifly, this tarp is built for those that want the simplicity and convenience of a standard hex tarp but with extra end-coverage when the weather gets nasty. If you're looking for something slightly lighter and smaller, check out MiniFly tarp model, it's a slightly downsized version of the ThunderFly and will save you a couple grams while still offering great coverage.",
        thumbnailUrl: "/products/warbonnet-outdoors-thunderfly-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ColorOption.Brown.Id,
            ["/products/warbonnet-outdoors-thunderfly-brn.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.OliveGreen.Id,
            ["/products/warbonnet-outdoors-thunderfly-olvgrn.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.DarkFoliageGreen.Id,
            ["/products/warbonnet-outdoors-thunderfly-dfgrn.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.RangerGreen.Id,
            ["/products/warbonnet-outdoors-thunderfly-rgrn.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.AutumnOrange.Id,
            ["/products/warbonnet-outdoors-thunderfly-aorg.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.OceanBlue.Id,
            ["/products/warbonnet-outdoors-thunderfly-oblu.webp"]),

        ProductImage.Create(
            Product.Id,
            [
                "/products/warbonnet-outdoors-thunderfly-1.webp",
                "/products/warbonnet-outdoors-thunderfly-2.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "WBO-TFLY-BRN",
            244.00m,
            5,
            [ColorOption.Brown]),

        Sku.Create(
            Product.Id,
            "WBO-TFLY-OLVGRN",
            244.00m,
            4,
            [ColorOption.OliveGreen]),

        Sku.Create(
            Product.Id,
            "WBO-TFLY-DFGRN",
            244.00m,
            7,
            [ColorOption.DarkFoliageGreen]),

        Sku.Create(
            Product.Id,
            "WBO-TFLY-RGRN",
            244.00m,
            0,
            [ColorOption.RangerGreen]),

        Sku.Create(
            Product.Id,
            "WBO-TFLY-AORG",
            202.00m,
            6,
            [ColorOption.AutumnOrange]),

        Sku.Create(
            Product.Id,
            "WBO-TFLY-OBLU",
            202.00m,
            3,
            [ColorOption.OceanBlue])
    ];
}