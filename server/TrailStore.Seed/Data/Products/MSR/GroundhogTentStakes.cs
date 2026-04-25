using TrailStore.Domain.Models;
 
namespace TrailStore.Seed.Data.Products.MSR;
 
// ReSharper disable UnusedType.Global
 
public sealed class GroundhogTentStakes
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:         "Groundhog Tent Stakes",
        slug:         "msr-groundhog-tent-stakes",
        brandId:      Brands.MSR.Id,
        categoryId:   Categories.Accessories.Id,
        description:  "MSR Groundhog™ Tent Stakes - are the go-to choice for most backpackers and are the most popular designs MSR offers. The Groundhogs sturdy Y-beam design provides solid anchoring in almost any soil environment. Constructed from 7000-series aluminum, this stake is light, strong, rugged and stands up to repeated use. Because of their design, they have incredible holding power and, when set properly, will hold up to any weather conditions. Each stake comes with an attached reflective pull loop for convenient removal and the bright color makes them easy to find.\nAt just 14 grams a piece the groundhog stake  isn't exactly \"ultralight\" but they're definitely reasonably lightweight for use in a backcountry. If you need a lighter stake the mini groundhog weighs just 10 grams and offers similar performance. Both stakes are standard equipment on new MSR tents and shelters. You can't go wrong with MSR stakes.",
        thumbnailUrl: "products/msr-groundhog-tent-stakes-thumb.webp");
 
    [SeededEntity]
    public static readonly IEnumerable<ProductImage> Images =
    [
        ProductImage.Create(
            productId: Product.Id,
            urls:      ["products/msr-groundhog-tent-stakes-1.webp"]),
    ];
 
    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "MSR-GRDHGSTK-STD",
            price: 27.00m,
            stock: 18,
            options: []),
    ];
}