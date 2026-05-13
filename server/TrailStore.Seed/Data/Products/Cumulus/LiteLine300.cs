using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Cumulus;

// ReSharper disable UnusedType.Global
public static class LiteLine300
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Lite Line 300",
        "cumulus-lite-line-300",
        brandId: Brands.Cumulus.Id,
        categoryId: Categories.SleepingBags.Id,
        description:
        """
        The Cumulus Lite Line 300 is a Polish-made ultralight sleeping bag built for spring and summer backpacking, filled with 300g of 850 FP ethically sourced Polish goose down.

        The Pertex Quantum shell weighs just 29 g/m², keeping total weight at 600g (21.2 oz). Comfort rating is 4°C with a limit of 0°C. Fits users up to 185cm (6'1") and packs down to around 4.5L. Full-length YKK zipper with anti-snag strip and a 3D anatomic hood round out the features.

        Hand sewn start to finish, with a lifetime warranty.
        """,
        thumbnailUrl: "/products/cumulus-lite-line-300-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/cumulus-lite-line-300-1.webp",
                "/products/cumulus-lite-line-300-2.webp",
                "/products/cumulus-lite-line-300-3.webp",
                "/products/cumulus-lite-line-300-4.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "CLMS-LITELINE300-LFT",
            316.00m,
            2,
            [ZipOption.Left]),

        Sku.Create(
            Product.Id,
            "CLMS-LITELINE300-RGT",
            316.00m,
            0,
            [ZipOption.Right])
    ];
}