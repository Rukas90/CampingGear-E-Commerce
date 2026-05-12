using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Products.Garmin;

// ReSharper disable UnusedType.Global
public static class Gpsmap67
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "GPSMAP 67",
        "garmin-gpsmap-67",
        brandId: Brands.Garmin.Id,
        categoryId: Categories.HandheldGps.Id,
        thumbnailUrl: "/products/garmin-gpsmap-67-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/garmin-gpsmap-67-1.webp",
                "/products/garmin-gpsmap-67-2.webp",
                "/products/garmin-gpsmap-67-3.webp",
                "/products/garmin-gpsmap-67-4.webp",
                "/products/garmin-gpsmap-67-5.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "GARMIN-GPSMAP67-STD",
            499.99m,
            15,
            [])
    ];
}