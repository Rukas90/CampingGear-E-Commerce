using TrailStore.Domain.Models;

namespace TrailStore.Seed.Data.Products.Gregory;

// ReSharper disable UnusedType.Global

public static class Baltoro75
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Baltoro 75",
        slug:         "gregory-baltoro-75",
        brandId:      Brands.Gregory.Id,
        categoryId:   Categories.Backpacks.Id,
        thumbnailUrl: "/products/gregory-baltoro-75-thumb.webp");

    [SeededEntity] 
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id, 
            urls:      ["/products/gregory-baltoro-75-1.webp",
                        "/products/gregory-baltoro-75-2.webp"]),
    ];
    
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "GREG-BALTORO-75-STD",
            price: 400.00m,
            stock: 3,
            options: []),
    ];
}