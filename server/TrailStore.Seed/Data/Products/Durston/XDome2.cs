using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Durston;

// ReSharper disable UnusedType.Global
public static class XDome2
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "X-Dome 2",
        "durston-x-dome-2",
        brandId: Brands.Durston.Id,
        categoryId: Categories.Tents.Id,
        thumbnailUrl: "/products/durston-x-dome-2-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/durston-x-dome-2-1.webp",
                "/products/durston-x-dome-2-2.webp",
                "/products/durston-x-dome-2-3.webp",
                "/products/durston-x-dome-2-4.webp",
                "/products/durston-x-dome-2-5.webp",
                "/products/durston-x-dome-2-6.webp",
                "/products/durston-x-dome-2-7.webp",
                "/products/durston-x-dome-2-8.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "DRST-XDOME2-REG-ALU",
            530.00m,
            1,
            [InteriorOption.Regular, PoleSetOption.Aluminum]),

        Sku.Create(
            Product.Id,
            "DRST-XDOME2-REG-CRBN",
            635.00m,
            0,
            [InteriorOption.Regular, PoleSetOption.Carbon]),

        Sku.Create(
            Product.Id,
            "DRST-XDOME2-REG-CRBNSHT",
            660.00m,
            1,
            [InteriorOption.Regular, PoleSetOption.CarbonShort]),

        Sku.Create(
            Product.Id,
            "DRST-XDOME2-SLD-ALU",
            564.00m,
            5,
            [InteriorOption.Solid, PoleSetOption.Aluminum]),

        Sku.Create(
            Product.Id,
            "DRST-XDOME2-SLD-CRBN",
            665.00m,
            0,
            [InteriorOption.Solid, PoleSetOption.Carbon]),

        Sku.Create(
            Product.Id,
            "DRST-XDOME2-SLD-CRBNSHT",
            689.00m,
            2,
            [InteriorOption.Solid, PoleSetOption.CarbonShort])
    ];
}