using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global
public static class ArcBackpackBelt
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Arc Backpack Belt",
        "zpacks-arc-backpack-belt",
        brandId: Brands.Zpacks.Id,
        categoryId: Categories.CareProtection.Id,
        description:
        """
        The Zpacks Arc Backpack Belt is a replacement and spare belt designed for the full Arc Series lineup — Arc Haul, Arc Haul Ultra, Arc Blast, and Arc Zip packs.

        All Arc Series belts are removable and interchangeable, making this a practical pickup if your waist size changes on a long trail, you're sharing the pack with someone else, or the original belt wears out before the rest of the pack. Features dual-adjust webbing and 3/8" closed cell foam padding for comfortable hip load transfer. Note: a 10.5" horizontal belt stay is required to attach the belt to a framed Arc pack and is sold separately.

        Size by measuring your waist where you want the belt to ride, then choose a belt a couple of inches smaller than that measurement to leave room for adjustment.
        """,
        thumbnailUrl: "/products/zpacks-arc-backpack-belt-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/zpacks-arc-backpack-belt-1.webp",
                "/products/zpacks-arc-backpack-belt-2.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "ZP-ARCBLT-SM",
            79.00m,
            8,
            [SizeOption.Small]),

        Sku.Create(
            Product.Id,
            "ZP-ARCBLT-MD",
            79.00m,
            11,
            [SizeOption.Medium]),

        Sku.Create(
            Product.Id,
            "ZP-ARCBLT-LG",
            79.00m,
            6,
            [SizeOption.Large]),

        Sku.Create(
            Product.Id,
            "ZP-ARCBLT-XL",
            79.00m,
            3,
            [SizeOption.XL])
    ];
}