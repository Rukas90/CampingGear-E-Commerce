using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Products.Garmin;

public sealed class Gpsmap67i
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "GPSMAP 67i",
        slug:         "garmin-gpsmap-67i",
        brandId:      Brands.Garmin.Id,
        categoryId:   Categories.HandheldGps.Id,
        thumbnailUrl: "products/garmin-gpsmap-67i-thumb.webp");
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code:      "GARMIN-GPSMAP67i-STD",
            price:     649.99m,
            stock:     8,
            options:   []),
    ];
}