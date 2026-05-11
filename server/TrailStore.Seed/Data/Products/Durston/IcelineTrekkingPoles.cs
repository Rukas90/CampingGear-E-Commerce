using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Products.Durston;

// ReSharper disable UnusedType.Global

public static class IcelineTrekkingPoles
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Iceline Trekking Poles",
        slug:         "durston-iceline-trekking-poles",
        brandId:      Brands.Durston.Id,
        categoryId:   Categories.TrekkingPoles.Id,
        thumbnailUrl: "/products/durston-iceline-trekking-poles-thumb.webp");
    
    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["/products/durston-iceline-trekking-poles-1.webp",
                        "/products/durston-iceline-trekking-poles-2.webp",
                        "/products/durston-iceline-trekking-poles-3.webp",
                        "/products/durston-iceline-trekking-poles-4.webp"]),
    ];
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "DRST-ICLNTRKPOL-STD",
            price: 225.00m,
            stock: 0,
            options: []),
    ];
}