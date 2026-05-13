using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Cumulus;

// ReSharper disable UnusedType.Global
public static class Teneqa850
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Teneqa 850",
        "cumulus-teneqa-850",
        brandId: Brands.Cumulus.Id,
        categoryId: Categories.SleepingBags.Id,
        description:
        """
        The Cumulus Teneqa 850 is a Polish-made ultralight four-season sleeping bag for demanding winter conditions, filled with 850g of 850 FP ethically sourced Polish goose down in a Pertex Quantum 29 g/m² shell.

        Comfort rating is -15°C with a limit of -23°C and an extreme of -46°C. Total weight is 1,310g (46.2 oz), fits users up to 190cm (6'3"), and packs to 11.1L. Features 44 V-chambers, an independently adjustable 3D collar and hood, shark-fin footbox, and twin down-filled draft tubes along the full-length YKK zipper.

        A step up from the Teneqa 700 for those regularly camping in harsher winter temperatures. Hand sewn start to finish, with a lifetime warranty.
        """,
        thumbnailUrl: "/products/cumulus-teneqa-850-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            [
                "/products/cumulus-teneqa-850-1.webp",
                "/products/cumulus-teneqa-850-2.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "CLMS-TENEQA850-LFT",
            565.00m,
            0,
            [ZipOption.Left]),

        Sku.Create(
            Product.Id,
            "CLMS-TENEQA850-RGT",
            565.00m,
            0,
            [ZipOption.Right])
    ];
}