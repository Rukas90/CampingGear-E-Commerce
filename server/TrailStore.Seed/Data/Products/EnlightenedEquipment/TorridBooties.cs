using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.EnlightenedEquipment;

// ReSharper disable UnusedType.Global

public static class TorridBooties
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Torrid Booties",
        slug:         "enlightened-equipment-torrid-booties",
        brandId:      Brands.EnlightenedEquipment.Id,
        categoryId:   Categories.Quilts.Id,
        thumbnailUrl: "/products/enlightened-equipment-torrid-booties-thumb.webp");

    [SeededEntity] 
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id, 
            urls:      ["/products/enlightened-equipment-torrid-booties-1.webp"])
    ];
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "EE-TRRBOOT-SM",
            price: 81.00m,
            stock: 7,
            options: [SizeOption.Small]),

        Sku.Create(
            productId: Product.Id,
            code: "EE-TRRBOOT-MD",
            price: 81.00m,
            stock: 9,
            options: [SizeOption.Medium]),

        Sku.Create(
            productId: Product.Id,
            code: "EE-TRRBOOT-LG",
            price: 81.00m,
            stock: 2,
            options: [SizeOption.Large]),

        Sku.Create(
            productId: Product.Id,
            code: "EE-TRRBOOT-XL",
            price: 81.00m,
            stock: 0,
            options: [SizeOption.XL]),

        Sku.Create(
            productId: Product.Id,
            code: "EE-TRRBOOT-2XL",
            price: 81.00m,
            stock: 0,
            options: [SizeOption.XXL]),
    ];
}