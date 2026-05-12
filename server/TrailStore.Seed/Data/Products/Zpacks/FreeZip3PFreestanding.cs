using TrailStore.Domain.Shared.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global
public static class FreeZip3PFreestanding
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        "Free Zip 3P Freestanding",
        "zpacks-free-zip-3p-freestanding",
        brandId: Brands.Zpacks.Id,
        categoryId: Categories.Tents.Id,
        description:
        "Zpacks Free Zip 3P Freestanding Tent - weighing it around 1 kg, this tent combines simplicity and versatility, setting it apart from most other ultralight backpacking tents. On calm nights, it can be set up without stakes or guy-lines, while in stormy alpine conditions, it can be securely anchored with up to 10 stakes. Its freestanding design makes it ideal for challenging terrains such as beach sand, snow, granite, tent platforms, and compacted sites, where trekking pole style tents can be more difficult to pitch. Whether you're ultralight backpacking, bikepacking, or packing for a canoe or kayak trip, the Free Zip 3P is a reliable choice.",
        thumbnailUrl: "/products/zpacks-free-zip-3p-freestanding-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            Product.Id,
            ColorOption.SpruceGreen.Id,
            ["/products/zpacks-free-zip-3p-freestanding-sgrn.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.Blue.Id,
            ["/products/zpacks-free-zip-3p-freestanding-blu.webp"]),

        ProductImage.Create(
            Product.Id,
            ColorOption.Olive.Id,
            ["/products/zpacks-free-zip-3p-freestanding-olv.webp"])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            Product.Id,
            "ZP-FRZP3PFS-SGRN",
            1209.00m,
            3,
            [ColorOption.SpruceGreen]),

        Sku.Create(
            Product.Id,
            "ZP-FRZP3PFS-BLU",
            1209.00m,
            4,
            [ColorOption.Blue]),

        Sku.Create(
            Product.Id,
            "ZP-FRZP3PFS-OLV",
            1209.00m,
            2,
            [ColorOption.Olive])
    ];
}