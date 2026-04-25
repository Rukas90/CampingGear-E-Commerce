using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Products.Durston;

// ReSharper disable UnusedType.Global

public sealed class XMid2
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "X-Mid 2",
        slug:         "durston-x-mid-2",
        brandId:      Brands.Durston.Id,
        categoryId:   Categories.Tents.Id,
        thumbnailUrl: "products/durston-x-mid-2-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["products/durston-x-mid-2-1.webp",
                        "products/durston-x-mid-2-2.webp",
                        "products/durston-x-mid-2-3.webp",
                        "products/durston-x-mid-2-4.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "DRST-XMID2-STD",
            price: 391.00m,
            stock: 7,
            options: []),
    ];
}