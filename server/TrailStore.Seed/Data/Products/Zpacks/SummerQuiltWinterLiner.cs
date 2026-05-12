using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global
public static class SummerQuiltWinterLiner
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Summer Quilt Winter Liner",
        "zpacks-summer-quilt-winter-liner",
        brandId: Brands.Zpacks.Id,
        categoryId: Categories.Quilts.Id,
        thumbnailUrl: "/products/zpacks-summer-quilt-winter-liner-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ColorOption.Blue.Id,
            ["/products/zpacks-summer-quilt-winter-liner-blu.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.Orange.Id,
            ["/products/zpacks-summer-quilt-winter-liner-org.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "ZP-SQWLNR-BLU-RGSHT",
            466.00m,
            4,
            [ColorOption.Blue, HeightOption.Regular, WidthOption.Narrow]),

        Sku.Create(
            Product.Id,
            "ZP-SQWLNR-BLU-RGMD",
            490.00m,
            6,
            [ColorOption.Blue, HeightOption.Regular, WidthOption.Medium]),

        Sku.Create(
            Product.Id,
            "ZP-SQWLNR-BLU-RGLNG",
            520.00m,
            3,
            [ColorOption.Blue, HeightOption.Regular, WidthOption.Wide]),

        Sku.Create(
            Product.Id,
            "ZP-SQWLNR-BLU-WDMD",
            520.00m,
            5,
            [ColorOption.Blue, HeightOption.Tall, WidthOption.Medium]),

        Sku.Create(
            Product.Id,
            "ZP-SQWLNR-BLU-WDLNG",
            547.00m,
            2,
            [ColorOption.Blue, HeightOption.Tall, WidthOption.Wide]),

        Sku.Create(
            Product.Id,
            "ZP-SQWLNR-ORG-RGSHT",
            466.00m,
            3,
            [ColorOption.Orange, HeightOption.Regular, WidthOption.Narrow]),

        Sku.Create(
            Product.Id,
            "ZP-SQWLNR-ORG-RGMD",
            490.00m,
            7,
            [ColorOption.Orange, HeightOption.Regular, WidthOption.Medium]),

        Sku.Create(
            Product.Id,
            "ZP-SQWLNR-ORG-RGLNG",
            520.00m,
            5,
            [ColorOption.Orange, HeightOption.Regular, WidthOption.Wide]),

        Sku.Create(
            Product.Id,
            "ZP-SQWLNR-ORG-WDMD",
            520.00m,
            4,
            [ColorOption.Orange, HeightOption.Tall, WidthOption.Medium]),

        Sku.Create(
            Product.Id,
            "ZP-SQWLNR-ORG-WDLNG",
            547.00m,
            1,
            [ColorOption.Orange, HeightOption.Tall, WidthOption.Wide])
    ];
}