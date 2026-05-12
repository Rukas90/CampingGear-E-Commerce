using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.EnlightenedEquipment;

// ReSharper disable UnusedType.Global
public static class TorridHood
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Torrid Hood",
        "enlightened-equipment-torrid-hood",
        brandId: Brands.EnlightenedEquipment.Id,
        categoryId: Categories.Quilts.Id,
        thumbnailUrl: "/products/enlightened-equipment-torrid-hood-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ["/products/enlightened-equipment-torrid-hood-1.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "EE-TRRHOOD-SM",
            79.00m,
            6,
            [SizeOption.Small]),

        Sku.Create(
            Product.Id,
            "EE-TRRHOOD-MD",
            79.00m,
            8,
            [SizeOption.Medium]),

        Sku.Create(
            Product.Id,
            "EE-TRRHOOD-LG",
            79.00m,
            4,
            [SizeOption.Large])
    ];
}