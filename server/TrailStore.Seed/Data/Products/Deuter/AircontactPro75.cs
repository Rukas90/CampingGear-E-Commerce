using TrailStore.Domain.Shared.Models;

namespace TrailStore.Seed.Data.Products.Deuter;

// ReSharper disable All
public static class AircontactPro7510
{
    [SeededEntity] public static readonly Product Product = Product.Create(
        name: "Aircontact Pro 75+10",
        slug: "deuter-aircontact-pro-75-10",
        brandId: Brands.Deuter.Id,
        categoryId: Categories.Backpacks.Id,
        thumbnailUrl: "/products/deuter-aircontact-pro-75-10-thumb.webp");

    [SeededEntity] public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:
            [
                "/products/deuter-aircontact-pro-75-10-1.webp",
                "/products/deuter-aircontact-pro-75-10-2.webp",
                "/products/deuter-aircontact-pro-75-10-3.webp",
                "/products/deuter-aircontact-pro-75-10-4.webp",
                "/products/deuter-aircontact-pro-75-10-5.webp"
            ])
    ];

    [SeededEntity] public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "DEUT-AIRCTPRO7510-STD",
            price: 420.00m,
            stock: 4,
            options: [])
    ];
}