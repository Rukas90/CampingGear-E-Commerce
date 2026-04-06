using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Products.Garmin;

public sealed class Gpsmap67
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:       "GPSMAP 67",
        slug:       "garmin-gpsmap-67",
        brandId:    Brands.Garmin.Id,
        categoryId: Categories.HandheldGps.Id);
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code:      "GARMIN-GPSMAP67-STD",
            price:     499.99m,
            stock:     15,
            options:   []),
    ];
}