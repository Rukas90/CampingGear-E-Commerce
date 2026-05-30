using TrailStore.Domain.Orders.Enums;
using TrailStore.Domain.Payments.Enums;
using TrailStore.Domain.Shared.Enums;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class Order : IModel<Order>
{
    public required Id<Order> Id { get; init; }
    public Id<Customer>? CustomerId { get; init; }
    public required string EmailAddress { get; init; }
    public required OrderStatus Status { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required DateTime StatusUpdatedAt { get; init; }
    public required decimal TotalPrice { get; init; }
    public required string Currency { get; init; }
    public required int MaxPaymentAttempts { get; init; }
    public required PostalAddress ShippingAddress { get; init; }
    public required PostalAddress BillingAddress { get; init; }
    
    public Customer? Customer { get; private set; } = null;
    public ICollection<OrderItem> Items { get; private set; } = [];
    public ICollection<Payment> Payments { get; private set; } = [];

    public int PaymentAttempts => Payments.Count;
    public bool CanRetryPayment => PaymentAttempts < MaxPaymentAttempts;
    public Payment? ActivePayment => Payments.FirstOrDefault(payment => payment.Status == PaymentStatus.Pending);
    
    public static Order Create(
        string emailAddress, 
        decimal totalPrice, 
        string currency,
        PostalAddress shippingAddress,
        PostalAddress billingAddress,
        Id<Customer>? customerId = null)
        => new()
        {
            Id = Id<Order>.New(),
            CustomerId = customerId,
            Status = OrderStatus.Confirmed,
            CreatedAt = DateTime.UtcNow,
            StatusUpdatedAt = DateTime.UtcNow,
            EmailAddress = emailAddress,
            Currency = currency,
            MaxPaymentAttempts = 3,
            ShippingAddress = shippingAddress,
            BillingAddress = billingAddress,
            TotalPrice = totalPrice
        };
}