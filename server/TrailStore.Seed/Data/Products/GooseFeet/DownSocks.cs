using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.GooseFeet;

// ReSharper disable All

public sealed class DownSocks
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Down Socks",
        slug:         "goosefeet-gear-down-socks",
        brandId:      Brands.GooseFeet.Id,
        categoryId:   Categories.SleepingBags.Id,
        thumbnailUrl: "/products/goosefeet-gear-down-socks-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-SM-GRAY",
            price: 96.00m,
            stock: 0,
            options: [SizeOption.Small, ColorOption.Gray]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-SM-BLZONG",
            price: 96.00m,
            stock: 0,
            options: [SizeOption.Small, ColorOption.BlazeOrange]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-SM-CHLRED",
            price: 96.00m,
            stock: 0,
            options: [SizeOption.Small, ColorOption.ChiliRed]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-SM-BLU",
            price: 96.00m,
            stock: 0,
            options: [SizeOption.Small, ColorOption.Blue]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-SM-BLK",
            price: 96.00m,
            stock: 0,
            options: [SizeOption.Small, ColorOption.Black]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-MD-GRAY",
            price: 96.00m,
            stock: 2,
            options: [SizeOption.Medium, ColorOption.Gray]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-MD-BLZONG",
            price: 96.00m,
            stock: 0,
            options: [SizeOption.Medium, ColorOption.BlazeOrange]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-MD-CHLRED",
            price: 96.00m,
            stock: 0,
            options: [SizeOption.Medium, ColorOption.ChiliRed]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-MD-BLU",
            price: 96.00m,
            stock: 2,
            options: [SizeOption.Medium, ColorOption.Blue]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-MD-BLK",
            price: 96.00m,
            stock: 1,
            options: [SizeOption.Medium, ColorOption.Black]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-LG-GRAY",
            price: 96.00m,
            stock: 0,
            options: [SizeOption.Large, ColorOption.Gray]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-LG-BLZONG",
            price: 96.00m,
            stock: 1,
            options: [SizeOption.Large, ColorOption.BlazeOrange]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-LG-CHLRED",
            price: 96.00m,
            stock: 0,
            options: [SizeOption.Large, ColorOption.ChiliRed]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-LG-BLU",
            price: 96.00m,
            stock: 0,
            options: [SizeOption.Large, ColorOption.Blue]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-LG-BLK",
            price: 96.00m,
            stock: 0,
            options: [SizeOption.Large, ColorOption.Black]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-XL-GRAY",
            price: 96.00m,
            stock: 0,
            options: [SizeOption.XL, ColorOption.Gray]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-XL-BLZONG",
            price: 96.00m,
            stock: 1,
            options: [SizeOption.XL, ColorOption.BlazeOrange]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-XL-CHLRED",
            price: 96.00m,
            stock: 0,
            options: [SizeOption.XL, ColorOption.ChiliRed]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-XL-BLU",
            price: 96.00m,
            stock: 0,
            options: [SizeOption.XL, ColorOption.Blue]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GFG-DOWNSOCKS-XL-BLK",
            price: 96.00m,
            stock: 4,
            options: [SizeOption.XL, ColorOption.Black]),
    ];
}