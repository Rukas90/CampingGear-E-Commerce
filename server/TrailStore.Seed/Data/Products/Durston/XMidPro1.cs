using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Durston;

// ReSharper disable UnusedType.Global

public sealed class XMidPro1
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "X-Mid Pro 1",
        slug:         "durston-x-mid-pro-1",
        brandId:      Brands.Durston.Id,
        categoryId:   Categories.Tents.Id,
        thumbnailUrl: "products/durston-x-mid-pro-1-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["products/durston-x-mid-pro-1-1.webp",
                        "products/durston-x-mid-pro-1-2.webp",
                        "products/durston-x-mid-pro-1-3.webp",
                        "products/durston-x-mid-pro-1-4.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "DRST-XMIDPRO1-WVN",
            price: 768.00m,
            stock: 5,
            options: [FloorOption.Woven]),

        Sku.Create(
            productId: Product.Id,
            code: "DRST-XMIDPRO1-DYN",
            price: 886.00m,
            stock: 3,
            options: [FloorOption.Dyneema]),
    ];
}