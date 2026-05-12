using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.GooseFeet;

// ReSharper disable UnusedType.Global
public static class DownSocks
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Down Socks",
        "goosefeet-gear-down-socks",
        brandId: Brands.GooseFeet.Id,
        categoryId: Categories.SleepingBags.Id,
        thumbnailUrl: "/products/goosefeet-gear-down-socks-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ColorOption.Gray.Id,
            ["/products/goosefeet-gear-down-socks-gray.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.BlazeOrange.Id,
            ["/products/goosefeet-gear-down-socks-blzong.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.ChiliRed.Id,
            ["/products/goosefeet-gear-down-socks-chlred.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.Blue.Id,
            ["/products/goosefeet-gear-down-socks-blu.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.Black.Id,
            ["/products/goosefeet-gear-down-socks-blk.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-SM-GRAY",
            96.00m,
            0,
            [SizeOption.Small, ColorOption.Gray]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-SM-BLZONG",
            96.00m,
            0,
            [SizeOption.Small, ColorOption.BlazeOrange]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-SM-CHLRED",
            96.00m,
            0,
            [SizeOption.Small, ColorOption.ChiliRed]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-SM-BLU",
            96.00m,
            0,
            [SizeOption.Small, ColorOption.Blue]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-SM-BLK",
            96.00m,
            0,
            [SizeOption.Small, ColorOption.Black]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-MD-GRAY",
            96.00m,
            2,
            [SizeOption.Medium, ColorOption.Gray]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-MD-BLZONG",
            96.00m,
            0,
            [SizeOption.Medium, ColorOption.BlazeOrange]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-MD-CHLRED",
            96.00m,
            0,
            [SizeOption.Medium, ColorOption.ChiliRed]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-MD-BLU",
            96.00m,
            2,
            [SizeOption.Medium, ColorOption.Blue]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-MD-BLK",
            96.00m,
            1,
            [SizeOption.Medium, ColorOption.Black]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-LG-GRAY",
            96.00m,
            0,
            [SizeOption.Large, ColorOption.Gray]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-LG-BLZONG",
            96.00m,
            1,
            [SizeOption.Large, ColorOption.BlazeOrange]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-LG-CHLRED",
            96.00m,
            0,
            [SizeOption.Large, ColorOption.ChiliRed]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-LG-BLU",
            96.00m,
            0,
            [SizeOption.Large, ColorOption.Blue]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-LG-BLK",
            96.00m,
            0,
            [SizeOption.Large, ColorOption.Black]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-XL-GRAY",
            96.00m,
            0,
            [SizeOption.XL, ColorOption.Gray]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-XL-BLZONG",
            96.00m,
            1,
            [SizeOption.XL, ColorOption.BlazeOrange]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-XL-CHLRED",
            96.00m,
            0,
            [SizeOption.XL, ColorOption.ChiliRed]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-XL-BLU",
            96.00m,
            0,
            [SizeOption.XL, ColorOption.Blue]),

        Sku.Create(
            Product.Id,
            "GFG-DOWNSOCKS-XL-BLK",
            96.00m,
            4,
            [SizeOption.XL, ColorOption.Black])
    ];
}