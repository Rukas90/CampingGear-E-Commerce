using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Products.Vargo;

// ReSharper disable UnusedType.Global

public static class DigDigTool
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Dig Dig Tool",
        slug:         "vargo-dig-dig-tool",
        brandId:      Brands.Vargo.Id,
        categoryId:   Categories.Accessories.Id,
        description:  "VARGO Dig Dig Tool - is a great multi purpose titanium trowel for digging catholes or securing your shelter. The Dig Dig Tool's™ ergonomic design is easier and more efficient to use while its rounded handle won't \"dig\" into your hand like other trowels and allows you to use a two-handed technique for even more dirt digging power and leverage. Its serrated edges slice through tough ground and roots so it can dig where other trowels can't. As a tent stake, its wide U-shape design holds firmly in hard and soft soils alike (even snow or sand!). Made from strong, lightweight titanium, it buries other trowels in the dirt.",
        thumbnailUrl: "/products/vargo-dig-dig-tool-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["/products/vargo-dig-dig-tool-1.webp",
                        "/products/vargo-dig-dig-tool-2.webp",
                        "/products/vargo-dig-dig-tool-3.webp",
                        "/products/vargo-dig-dig-tool-4.webp",
                        "/products/vargo-dig-dig-tool-5.webp"]),
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "VRG-DGDGTL-STD",
            price: 30.00m,
            stock: 14,
            options: []),
    ];
}