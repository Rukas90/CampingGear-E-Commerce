using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Vargo;

// ReSharper disable UnusedType.Global
public static class TitaniumTentStake
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Titanium Tent Stake",
        "vargo-titanium-tent-stake",
        brandId: Brands.Vargo.Id,
        categoryId: Categories.Accessories.Id,
        description:
        "VARGO Titanium Tent Stake - is great lightweight original Vargo Titanium Tent Stake in the classic shepherd's hook design with orange fluorescent coated heads for increased visibility. The orange heads make them easy to find on any terrain and even in low light and prevent to get them lost. They are easy to put into relatively hard ground as long as it's not too rocky. Will be a great addition to your tent stakes kit.",
        thumbnailUrl: "/products/vargo-titanium-tent-stake-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            PackOption.Single.Id,
            ["/products/vargo-titanium-tent-stake-single.webp"]),

        ProductImage.Create(
            Product.Id,
            PackOption.Pack6.Id,
            ["/products/vargo-titanium-tent-stake-pack6.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "VRG-TITSTK-SNGL",
            4.00m,
            24,
            [PackOption.Single]),

        Sku.Create(
            Product.Id,
            "VRG-TITSTK-PCK6",
            24.00m,
            11,
            [PackOption.Pack6])
    ];
}