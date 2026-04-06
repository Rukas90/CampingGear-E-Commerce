using TrailStore.Domain.Models;
using TrailStore.Seed.Data.Options;

namespace TrailStore.Seed.Data.Products.Gossamer;

public sealed class Kumo36Superlight
{
    [SeededEntity]
    public static readonly Product Product = Product.Create(
        name:       "Kumo36 Superlight",
        slug:       "gossamer-gear-kumo36-superlight",
        brandId:    Brands.Gossamer.Id,
        categoryId: Categories.Backpacks.Id);

    [SeededEntity]
    public static readonly IEnumerable<Sku> Skus =
    [
        Sku.Create(
            productId: Product.Id,
            code: "GG-KUMO36-GRAY-SM",
            price: 195.00m,
            stock: 0,
            options: [ColorOption.Gray, SizeOption.Small]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GG-KUMO36-GRY-MD",
            price: 195.00m,
            stock: 3,
            options: [ColorOption.Gray, SizeOption.Medium]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GG-KUMO36-YLW-SM",
            price: 195.00m,
            stock: 8,
            options: [ColorOption.Yellow, SizeOption.Small]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GG-KUMO36-YLW-MD",
            price: 195.00m,
            stock: 1,
            options: [ColorOption.Yellow, SizeOption.Medium]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GG-KUMO36-PRPL-SM",
            price: 195.00m,
            stock: 4,
            options: [ColorOption.Purple, SizeOption.Small]),
        
        Sku.Create(
            productId: Product.Id,
            code: "GG-KUMO36-PRPL-MD",
            price: 195.00m,
            stock: 6,
            options: [ColorOption.Purple, SizeOption.Medium]),
    ];
}