using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.EnlightenedEquipment;

// ReSharper disable UnusedType.Global
public static class TorridBooties
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Torrid Booties",
        "enlightened-equipment-torrid-booties",
        brandId: Brands.EnlightenedEquipment.Id,
        categoryId: Categories.Quilts.Id,
        thumbnailUrl: "/products/enlightened-equipment-torrid-booties-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ["/products/enlightened-equipment-torrid-booties-1.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "EE-TRRBOOT-SM",
            81.00m,
            7,
            [SizeOption.Small]),

        Sku.Create(
            Product.Id,
            "EE-TRRBOOT-MD",
            81.00m,
            9,
            [SizeOption.Medium]),

        Sku.Create(
            Product.Id,
            "EE-TRRBOOT-LG",
            81.00m,
            2,
            [SizeOption.Large]),

        Sku.Create(
            Product.Id,
            "EE-TRRBOOT-XL",
            81.00m,
            0,
            [SizeOption.XL]),

        Sku.Create(
            Product.Id,
            "EE-TRRBOOT-2XL",
            81.00m,
            0,
            [SizeOption.XXL])
    ];
}