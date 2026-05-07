using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Products.Durston;

// ReSharper disable UnusedType.Global

public static class XMid1
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "X-Mid 1",
        slug:         "durston-x-mid-1",
        brandId:      Brands.Durston.Id,
        categoryId:   Categories.Tents.Id,
        thumbnailUrl: "/products/durston-x-mid-1-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["/products/durston-x-mid-1-1.webp",
                        "/products/durston-x-mid-1-2.webp",
                        "/products/durston-x-mid-1-3.webp",
                        "/products/durston-x-mid-1-4.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "DRST-XMID1-STD",
            price: 341.00m,
            stock: 0,
            options: []),
    ];
}