using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global

public sealed class SummerTwinQuilt
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Summer Twin Quilt",
        slug:         "zpacks-summer-twin-quilt",
        brandId:      Brands.Zpacks.Id,
        categoryId:   Categories.Quilts.Id,
        thumbnailUrl: "products/zpacks-summer-twin-quilt-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.Blue.Id,
            urls:      ["products/zpacks-summer-twin-quilt-blu.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "ZP-SMRTWN-BLU-MD",
            price: 594.00m,
            stock: 5,
            options: [ColorOption.Blue, SizeOption.Medium]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-SMRTWN-BLU-LG",
            price: 617.00m,
            stock: 3,
            options: [ColorOption.Blue, SizeOption.Large]),
    ];
}