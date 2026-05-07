using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Durston;

// ReSharper disable UnusedType.Global

public static class XDome2
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "X-Dome 2",
        slug:         "durston-x-dome-2",
        brandId:      Brands.Durston.Id,
        categoryId:   Categories.Tents.Id,
        thumbnailUrl: "/products/durston-x-dome-2-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["/products/durston-x-dome-2-1.webp",
                        "/products/durston-x-dome-2-2.webp",
                        "/products/durston-x-dome-2-3.webp",
                        "/products/durston-x-dome-2-4.webp",
                        "/products/durston-x-dome-2-5.webp",
                        "/products/durston-x-dome-2-6.webp",
                        "/products/durston-x-dome-2-7.webp",
                        "/products/durston-x-dome-2-8.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "DRST-XDOME2-REG-ALU",
            price: 530.00m,
            stock: 1,
            options: [InteriorOption.Regular, PoleSetOption.Aluminum]),

        Sku.Create(
            productId: Product.Id,
            code: "DRST-XDOME2-REG-CRBN",
            price: 635.00m,
            stock: 0,
            options: [InteriorOption.Regular, PoleSetOption.Carbon]),

        Sku.Create(
            productId: Product.Id,
            code: "DRST-XDOME2-REG-CRBNSHT",
            price: 660.00m,
            stock: 1,
            options: [InteriorOption.Regular, PoleSetOption.CarbonShort]),

        Sku.Create(
            productId: Product.Id,
            code: "DRST-XDOME2-SLD-ALU",
            price: 564.00m,
            stock: 5,
            options: [InteriorOption.Solid, PoleSetOption.Aluminum]),

        Sku.Create(
            productId: Product.Id,
            code: "DRST-XDOME2-SLD-CRBN",
            price: 665.00m,
            stock: 0,
            options: [InteriorOption.Solid, PoleSetOption.Carbon]),

        Sku.Create(
            productId: Product.Id,
            code: "DRST-XDOME2-SLD-CRBNSHT",
            price: 689.00m,
            stock: 2,
            options: [InteriorOption.Solid, PoleSetOption.CarbonShort]),
    ];
}