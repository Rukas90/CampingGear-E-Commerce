using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global

public sealed class FreeZip3PFreestanding
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Free Zip 3P Freestanding",
        slug:         "zpacks-free-zip-3p-freestanding",
        brandId:      Brands.Zpacks.Id,
        categoryId:   Categories.Tents.Id,
        description:  "Zpacks Free Zip 3P Freestanding Tent - weighing it around 1 kg, this tent combines simplicity and versatility, setting it apart from most other ultralight backpacking tents. On calm nights, it can be set up without stakes or guy-lines, while in stormy alpine conditions, it can be securely anchored with up to 10 stakes. Its freestanding design makes it ideal for challenging terrains such as beach sand, snow, granite, tent platforms, and compacted sites, where trekking pole style tents can be more difficult to pitch. Whether you're ultralight backpacking, bikepacking, or packing for a canoe or kayak trip, the Free Zip 3P is a reliable choice.",
        thumbnailUrl: "/products/zpacks-free-zip-3p-freestanding-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.SpruceGreen.Id,
            urls:      ["/products/zpacks-free-zip-3p-freestanding-sgrn.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.Blue.Id,
            urls:      ["/products/zpacks-free-zip-3p-freestanding-blu.webp"]),

        ProductImage.Create(
            productId: Product.Id,
            optionId:  ColorOption.Olive.Id,
            urls:      ["/products/zpacks-free-zip-3p-freestanding-olv.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "ZP-FRZP3PFS-SGRN",
            price: 1209.00m,
            stock: 3,
            options: [ColorOption.SpruceGreen]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-FRZP3PFS-BLU",
            price: 1209.00m,
            stock: 4,
            options: [ColorOption.Blue]),

        Sku.Create(
            productId: Product.Id,
            code: "ZP-FRZP3PFS-OLV",
            price: 1209.00m,
            stock: 2,
            options: [ColorOption.Olive]),
    ];
}