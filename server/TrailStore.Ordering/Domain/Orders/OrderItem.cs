using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Ordering.Domain.Financials;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Orders;

public class OrderItem : IModel<OrderItem>
{
    public required Id<OrderItem> Id { get; init; }
    public required Id<Order> OrderId { get; init; }
    public required Id<SkuRef> SkuId { get; init; }
    public required string BrandName { get; init; }
    public required string ProductName { get; init; }
    public required string VariantLine { get; init; }
    public string? ThumbnailUrl { get; init; }
    public required int Quantity { get; init; }
    public required decimal UnitPrice { get; init; }
    public required decimal TaxRate { get; init; }
    public required decimal TaxAmount { get; init; }
    public required decimal PriceBeforeTax { get; init; }
    public required decimal PriceAfterTax { get; init; }
    
    public LineFinancials Financials
        => new()
        {
            PriceBeforeTax = PriceBeforeTax,
            TaxRate = TaxRate,
            TaxAmount = TaxAmount,
            PriceAfterTax = PriceAfterTax
        };
    
    public static OrderItem Create(
        Id<Order> orderId, 
        OrderLineItem source)
        => new()
        {
            Id = Id<OrderItem>.New(),
            OrderId = orderId,
            SkuId = source.SkuId,
            BrandName = source.BrandName,
            ProductName = source.ProductName,
            VariantLine = source.VariantLine,
            Quantity = source.Quantity,
            ThumbnailUrl = source.ThumbnailUrl,
            UnitPrice = source.UnitPrice,
            TaxRate = source.Financials.TaxRate,
            TaxAmount = source.Financials.TaxAmount,
            PriceBeforeTax = source.Financials.PriceBeforeTax,
            PriceAfterTax = source.Financials.PriceAfterTax
        };

    public OrderLineItem ToLineItem()
        => new(SkuId, BrandName, ProductName, VariantLine, UnitPrice, Quantity, ThumbnailUrl, Financials);
}