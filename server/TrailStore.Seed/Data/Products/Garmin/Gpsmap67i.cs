using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Products.Garmin;

// ReSharper disable UnusedType.Global
public static class Gpsmap67i
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "GPSMAP 67i",
        "garmin-gpsmap-67i",
        brandId: Brands.Garmin.Id,
        categoryId: Categories.HandheldGps.Id,
        thumbnailUrl: "/products/garmin-gpsmap-67i-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/garmin-gpsmap-67i-1.webp",
                "/products/garmin-gpsmap-67i-2.webp",
                "/products/garmin-gpsmap-67i-3.webp",
                "/products/garmin-gpsmap-67i-4.webp",
                "/products/garmin-gpsmap-67i-5.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "GARMIN-GPSMAP67i-STD",
            649.99m,
            8,
            [])
    ];
}