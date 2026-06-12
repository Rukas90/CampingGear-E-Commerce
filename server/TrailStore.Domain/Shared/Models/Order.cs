using TrailStore.Domain.Orders.Enums;
using TrailStore.Domain.Orders.Models;
using TrailStore.Domain.Payments.Enums;
using TrailStore.Domain.Shared.Interfaces;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class Order : IModel<Order>, IEntityCreatable
{
    public required Id<Order> Id { get; init; }
    public required string Token { get; init; }
    public Id<Customer>? CustomerId { get; init; }
    public required string EmailAddress { get; init; }
    public required OrderStatus Status { get; init; }
    public required DateTime StatusUpdatedAt { get; init; }
    public required decimal TotalPrice { get; init; }
    public required decimal TaxAmount { get; init; }
    public required int MaxPaymentAttempts { get; init; }
    public required ShippingAddress ShippingAddress { get; init; }
    public required BillingAddress BillingAddress { get; init; }
    
    public DateTime CreatedAt { get; set; }
    
    public Customer? Customer { get; private set; } = null;
    public ICollection<OrderItem> Items { get; private set; } = [];
    public ICollection<Payment> Payments { get; private set; } = [];

    public int PaymentAttempts => Payments.Count;
    public bool CanRetryPayment => PaymentAttempts < MaxPaymentAttempts;
    public Payment? ActivePayment => Payments.FirstOrDefault(payment => payment.Status == PaymentStatus.Pending);
    
    public static Order Create(
        Id<Order> id,
        string token,
        string emailAddress, 
        decimal totalPrice, 
        decimal taxAmount,
        ShippingAddress shippingAddress,
        BillingAddress billingAddress,
        Id<Customer>? customerId = null)
        => new()
        {
            Id = id,
            Token = token,
            CustomerId = customerId,
            Status = OrderStatus.Confirmed,
            StatusUpdatedAt = DateTime.UtcNow,
            EmailAddress = emailAddress,
            MaxPaymentAttempts = 1,
            ShippingAddress = shippingAddress,
            BillingAddress = billingAddress,
            TotalPrice = totalPrice,
            TaxAmount = taxAmount
        };
}