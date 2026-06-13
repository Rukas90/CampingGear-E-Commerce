using TrailStore.Domain.Orders.Enums;

namespace TrailStore.Domain.Orders.Models;

public class OrderSummary
{
    public required decimal TotalPrice { get; set; }
    public required decimal Subtotal { get; set; }
    public required decimal TaxAmount { get; set; }
    public required decimal ShippingAmount { get; set; }
    public required string ShippingMethod { get; set; }
    public required OrderStatus Status { get; init; }
    public required bool ExhaustedPaymentAttempts { get; init; }
    public required bool HasPendingPayment { get; set; }
    public required IEnumerable<OrderItemSummary> Items { get; set; }
}