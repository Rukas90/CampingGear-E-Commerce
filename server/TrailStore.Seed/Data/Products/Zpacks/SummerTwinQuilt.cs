using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global
public static class SummerTwinQuilt
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Summer Twin Quilt",
        "zpacks-summer-twin-quilt",
        brandId: Brands.Zpacks.Id,
        categoryId: Categories.Quilts.Id,
        thumbnailUrl: "/products/zpacks-summer-twin-quilt-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ColorOption.Blue.Id,
            ["/products/zpacks-summer-twin-quilt-blu.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "ZP-SMRTWN-BLU-MD",
            594.00m,
            5,
            [ColorOption.Blue, SizeOption.Medium]),

        Sku.Create(
            Product.Id,
            "ZP-SMRTWN-BLU-LG",
            617.00m,
            3,
            [ColorOption.Blue, SizeOption.Large])
    ];
}