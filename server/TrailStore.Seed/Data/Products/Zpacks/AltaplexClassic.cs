using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Products.Zpacks;

// ReSharper disable UnusedType.Global

public sealed class AltaplexClassic
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Altaplex Classic",
        slug:         "zpacks-altaplex-classic",
        brandId:      Brands.Zpacks.Id,
        categoryId:   Categories.Tents.Id,
        description:  "Zpacks Altaplex Tent - is the ultimate choice for solo backpackers up to 198 cm (6'6\") seeking a versatile and reliable shelter. This single-person tent is designed with simplicity and functionality in mind. Setting up the Altaplex is a breeze, requiring just a single trekking pole, typically adjusted to 142-147 cm. In windy conditions, it's recommended to use 10 stakes (minimum 6) for secure anchoring, ensuring your peace of mind in challenging weather.\nOne of the standout features of the Altaplex is its storm doors, which can be independently opened for ventilation or securely closed for rain protection using metal hooks. You won't have to worry about door zippers failing over time, a common concern with many tents.",
        thumbnailUrl: "/products/zpacks-altaplex-classic-thumb.webp");

    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["/products/zpacks-altaplex-classic-1.webp",
                        "/products/zpacks-altaplex-classic-2.webp",
                        "/products/zpacks-altaplex-classic-3.webp",
                        "/products/zpacks-altaplex-classic-4.webp",
                        "/products/zpacks-altaplex-classic-5.webp"])
    ];

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "ZP-ALTPLXCLS-STD",
            price: 883.00m,
            stock: 5,
            options: []),
    ];
}