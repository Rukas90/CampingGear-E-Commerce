using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Orders;

public class Order : AggregateRoot<Order>, IEntityCreatable
{
    public required string Token { get; init; }
    public Id<UserRef>? UserId { get; init; }
    public required string EmailAddress { get; init; }
    public required OrderStatus Status { get; init; }
    public required DateTime StatusUpdatedAt { get; init; }
    public required decimal TotalPrice { get; init; }
    public required decimal TaxAmount { get; init; }
    public required int MaxPaymentAttempts { get; init; }
    public required BillingAddress BillingAddress { get; init; }
    
    public DateTime CreatedAt { get; set; }
    
    public OrderShipping Shipping { get; private set; } = null!;
    public ICollection<OrderItem> Items { get; private set; } = [];
    // public ICollection<Payment> Payments { get; private set; } = [];

    // public int PaymentAttempts => Payments.Count;
    // public bool CanRetryPayment => PaymentAttempts < MaxPaymentAttempts;
    // public Payment? ActivePayment => Payments.FirstOrDefault(payment => payment.Status == PaymentStatus.Pending);
    
    public static Order Create(
        Id<Order> id,
        string token,
        string emailAddress, 
        decimal totalPrice, 
        decimal taxAmount,
        BillingAddress billingAddress,
        Id<UserRef>? userRef = null)
        => new()
        {
            Id = id,
            Token = token,
            UserId = userRef,
            Status = OrderStatus.Confirmed,
            StatusUpdatedAt = DateTime.UtcNow,
            EmailAddress = emailAddress,
            MaxPaymentAttempts = 1,
            BillingAddress = billingAddress,
            TotalPrice = totalPrice,
            TaxAmount = taxAmount
        };
}