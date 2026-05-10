using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global

public static class SummerQuiltWinterLiner
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Summer Quilt Winter Liner",
        slug:         "zpacks-summer-quilt-winter-liner",
        brandId:      Brands.Zpacks.Id,
        categoryId:   Categories.Quilts.Id,
        thumbnailUrl: "/products/zpacks-summer-quilt-winter-liner-thumb.webp");

    [SeededEntity] 
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id, 
            optionId:  ColorOption.Blue.Id, 
            urls:      ["/products/zpacks-summer-quilt-winter-liner-blu.webp"]),
        
        ProductImage.Create(
            productId: Product.Id, 
            optionId:  ColorOption.Orange.Id, 
            urls:      ["/products/zpacks-summer-quilt-winter-liner-org.webp"])
    ];
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "ZP-SQWLNR-BLU-RGSHT",
            price: 466.00m,
            stock: 4,
            options: [ColorOption.Blue, HeightOption.Regular, WidthOption.Narrow]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-SQWLNR-BLU-RGMD",
            price: 490.00m,
            stock: 6,
            options: [ColorOption.Blue, HeightOption.Regular, WidthOption.Medium]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-SQWLNR-BLU-RGLNG",
            price: 520.00m,
            stock: 3,
            options: [ColorOption.Blue, HeightOption.Regular, WidthOption.Wide]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-SQWLNR-BLU-WDMD",
            price: 520.00m,
            stock: 5,
            options: [ColorOption.Blue, HeightOption.Tall, WidthOption.Medium]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-SQWLNR-BLU-WDLNG",
            price: 547.00m,
            stock: 2,
            options: [ColorOption.Blue, HeightOption.Tall, WidthOption.Wide]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-SQWLNR-ORG-RGSHT",
            price: 466.00m,
            stock: 3,
            options: [ColorOption.Orange, HeightOption.Regular, WidthOption.Narrow]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-SQWLNR-ORG-RGMD",
            price: 490.00m,
            stock: 7,
            options: [ColorOption.Orange, HeightOption.Regular, WidthOption.Medium]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-SQWLNR-ORG-RGLNG",
            price: 520.00m,
            stock: 5,
            options: [ColorOption.Orange, HeightOption.Regular, WidthOption.Wide]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-SQWLNR-ORG-WDMD",
            price: 520.00m,
            stock: 4,
            options: [ColorOption.Orange, HeightOption.Tall, WidthOption.Medium]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-SQWLNR-ORG-WDLNG",
            price: 547.00m,
            stock: 1,
            options: [ColorOption.Orange, HeightOption.Tall, WidthOption.Wide]),
    ];
}