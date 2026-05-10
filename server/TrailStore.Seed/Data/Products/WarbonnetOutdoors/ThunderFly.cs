using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.WarbonnetOutdoors;

// ReSharper disable UnusedType.Global

public sealed class ThunderFly
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
            optionId:  ColorOption.Brown.Id,
            urls:      ["/products/warbonnet-outdoors-thunderfly-brn.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.OliveGreen.Id,
            urls:      ["/products/warbonnet-outdoors-thunderfly-olvgrn.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.DarkFoliageGreen.Id,
            urls:      ["/products/warbonnet-outdoors-thunderfly-dfgrn.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.RangerGreen.Id,
            urls:      ["/products/warbonnet-outdoors-thunderfly-rgrn.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.AutumnOrange.Id,
            urls:      ["/products/warbonnet-outdoors-thunderfly-aorg.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.OceanBlue.Id,
            urls:      ["/products/warbonnet-outdoors-thunderfly-oblu.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            urls:      ["/products/warbonnet-outdoors-thunderfly-1.webp",
                        "/products/warbonnet-outdoors-thunderfly-2.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "WBO-TFLY-BRN",
            price: 244.00m,
            stock: 5,
            options: [ColorOption.Brown]),

        Sku.Create(
            productId: Product.Id,
            code: "WBO-TFLY-OLVGRN",
            price: 244.00m,
            stock: 4,
            options: [ColorOption.OliveGreen]),

        Sku.Create(
            productId: Product.Id,
            code: "WBO-TFLY-DFGRN",
            price: 244.00m,
            stock: 7,
            options: [ColorOption.DarkFoliageGreen]),

        Sku.Create(
            productId: Product.Id,
            code: "WBO-TFLY-RGRN",
            price: 244.00m,
            stock: 0,
            options: [ColorOption.RangerGreen]),

        Sku.Create(
            productId: Product.Id,
            code: "WBO-TFLY-AORG",
            price: 202.00m,
            stock: 6,
            options: [ColorOption.AutumnOrange]),

        Sku.Create(
            productId: Product.Id,
            code: "WBO-TFLY-OBLU",
            price: 202.00m,
            stock: 3,
            options: [ColorOption.OceanBlue]),
    ];
}