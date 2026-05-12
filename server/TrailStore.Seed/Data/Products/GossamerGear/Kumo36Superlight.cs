using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.GossamerGear;

// ReSharper disable UnusedType.Global
public static class Kumo36Superlight
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Kumo36 Superlight",
        "gossamer-gear-kumo36-superlight",
        brandId: Brands.GossamerGear.Id,
        categoryId: Categories.Backpacks.Id,
        thumbnailUrl: "/products/gossamer-gear-kumo36-superlight-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ColorOption.Gray.Id,
            ["/products/gossamer-gear-kumo36-superlight-gray.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.Yellow.Id,
            ["/products/gossamer-gear-kumo36-superlight-ylw.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.Purple.Id,
            ["/products/gossamer-gear-kumo36-superlight-prpl.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "GG-KUMO36-GRAY-SM",
            195.00m,
            0,
            [ColorOption.Gray, SizeOption.Small]),

        Sku.Create(
            Product.Id,
            "GG-KUMO36-GRY-MD",
            195.00m,
            3,
            [ColorOption.Gray, SizeOption.Medium]),

        Sku.Create(
            Product.Id,
            "GG-KUMO36-YLW-SM",
            195.00m,
            8,
            [ColorOption.Yellow, SizeOption.Small]),

        Sku.Create(
            Product.Id,
            "GG-KUMO36-YLW-MD",
            195.00m,
            1,
            [ColorOption.Yellow, SizeOption.Medium]),

        Sku.Create(
            Product.Id,
            "GG-KUMO36-PRPL-SM",
            195.00m,
            4,
            [ColorOption.Purple, SizeOption.Small]),

        Sku.Create(
            Product.Id,
            "GG-KUMO36-PRPL-MD",
            195.00m,
            6,
            [ColorOption.Purple, SizeOption.Medium])
    ];
}