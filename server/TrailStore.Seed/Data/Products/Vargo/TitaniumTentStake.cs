using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Vargo;

// ReSharper disable UnusedType.Global

public static class TitaniumTentStake
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Titanium Tent Stake",
        slug:         "vargo-titanium-tent-stake",
        brandId:      Brands.Vargo.Id,
        categoryId:   Categories.Accessories.Id,
        description:  "VARGO Titanium Tent Stake - is great lightweight original Vargo Titanium Tent Stake in the classic shepherd's hook design with orange fluorescent coated heads for increased visibility. The orange heads make them easy to find on any terrain and even in low light and prevent to get them lost. They are easy to put into relatively hard ground as long as it's not too rocky. Will be a great addition to your tent stakes kit.",
        thumbnailUrl: "/products/vargo-titanium-tent-stake-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            optionId:  PackOption.Single.Id,
            urls:      ["/products/vargo-titanium-tent-stake-single.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  PackOption.Pack6.Id,
            urls:      ["/products/vargo-titanium-tent-stake-pack6.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "VRG-TITSTK-SNGL",
            price: 4.00m,
            stock: 24,
            options: [PackOption.Single]),

        Sku.Create(
            productId: Product.Id,
            code: "VRG-TITSTK-PCK6",
            price: 24.00m,
            stock: 11,
            options: [PackOption.Pack6]),
    ];
}