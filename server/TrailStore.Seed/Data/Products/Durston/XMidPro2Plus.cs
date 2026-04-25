using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Products.Durston;

// ReSharper disable UnusedType.Global

public sealed class XMidPro2Plus
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "X-Mid Pro 2+",
        slug:         "durston-x-mid-pro-2-plus",
        brandId:      Brands.Durston.Id,
        categoryId:   Categories.Tents.Id,
        thumbnailUrl: "products/durston-x-mid-pro-2-plus-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["products/durston-x-mid-pro-2-plus-1.webp",
                        "products/durston-x-mid-pro-2-plus-2.webp",
                        "products/durston-x-mid-pro-2-plus-3.webp",
                        "products/durston-x-mid-pro-2-plus-4.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "DRST-XMIDPRO2P-STD",
            price: 920.00m,
            stock: 4,
            options: []),
    ];
}