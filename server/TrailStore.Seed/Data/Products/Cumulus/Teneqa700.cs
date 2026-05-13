using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Cumulus;

// ReSharper disable UnusedType.Global
public static class Teneqa700
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Teneqa 700",
        "cumulus-teneqa-700",
        brandId: Brands.Cumulus.Id,
        categoryId: Categories.SleepingBags.Id,
        description:
        """
        The Cumulus Teneqa 700 is a Polish-made ultralight winter sleeping bag built for serious cold, filled with 700g of 850 FP ethically sourced Polish goose down in a Pertex Quantum 29 g/m² shell.

        Comfort rating is -9°C with a limit of -17°C and an extreme of -37°C. Total weight is 1,170g (41.3 oz), fits users up to 190cm (6'3"), and packs down to 10.4L. Features four full-length V-chambers, an independently adjustable 3D collar and hood, shark-fin footbox with extra down fill, and twin down-filled draft tubes along the full-length YKK zipper.

        Hand sewn start to finish, with a lifetime warranty.
        """,
        thumbnailUrl: "/products/cumulus-teneqa-700-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ["/products/cumulus-teneqa-700-1.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "CLMS-TENEQA700-LFT",
            515.00m,
            0,
            [ZipOption.Left]),

        Sku.Create(
            Product.Id,
            "CLMS-TENEQA700-RGT",
            515.00m,
            0,
            [ZipOption.Right])
    ];
}