using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Products.Durston;

// ReSharper disable UnusedType.Global

public sealed class XMid2Solid
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "X-Mid 2 Solid",
        slug:         "durston-x-mid-2-solid",
        brandId:      Brands.Durston.Id,
        categoryId:   Categories.Tents.Id,
        thumbnailUrl: "products/durston-x-mid-2-solid-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["products/durston-x-mid-2-solid-1.webp",
                        "products/durston-x-mid-2-solid-2.webp",
                        "products/durston-x-mid-2-solid-3.webp",
                        "products/durston-x-mid-2-solid-4.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "DRST-XMID2SLD-STD",
            price: 440.00m,
            stock: 6,
            options: []),
    ];
}