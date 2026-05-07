using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Durston;

// ReSharper disable UnusedType.Global

public static class XMidPro2
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "X-Mid Pro 2",
        slug:         "durston-x-mid-pro-2",
        brandId:      Brands.Durston.Id,
        categoryId:   Categories.Tents.Id,
        thumbnailUrl: "/products/durston-x-mid-pro-2-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["/products/durston-x-mid-pro-2-1.webp",
                        "/products/durston-x-mid-pro-2-2.webp",
                        "/products/durston-x-mid-pro-2-3.webp",
                        "/products/durston-x-mid-pro-2-4.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "DRST-XMIDPRO2-WVN",
            price: 901.00m,
            stock: 5,
            options: [FloorOption.Woven]),

        Sku.Create(
            productId: Product.Id,
            code: "DRST-XMIDPRO2-DYN",
            price: 1010.00m,
            stock: 1,
            options: [FloorOption.Dyneema]),
    ];
}