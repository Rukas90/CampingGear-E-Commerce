using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Domain.Payments;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Orders;

public class Order : AggregateRoot<Order>, IEntityCreatable, IEntityUpdateable
{
    public required string Token { get; init; }
    public Id<UserRef>? UserId { get; init; }
    public required string EmailAddress { get; init; }
    public required OrderStatus Status { get; init; }
    public required DateTime StatusUpdatedAt { get; init; }
    public required decimal Subtotal { get; init; }
    public required decimal TaxAmount { get; init; }
    public required decimal TotalPrice { get; init; }
    public required int MaxPaymentAttempts { get; init; }
    public required BillingAddress BillingAddress { get; init; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    private List<OrderItem> _items = [];
    public IReadOnlyList<OrderItem> Items => _items;
    
    private readonly List<Payment> _payments = [];
    public IReadOnlyList<Payment> Payments => _payments;

    public int PaymentAttempts => Payments.Count;
    public bool CanRetryPayment => PaymentAttempts < MaxPaymentAttempts;
    public Payment? ActivePayment => Payments.FirstOrDefault(payment => payment.Status == PaymentStatus.Pending);
    
    public OrderShipping Shipping { get; private set; } = null!;
    
    public static Order Create(OrderCreationInput input)
        => new()
        {
            Id = input.Id,
            Token = input.Token,
            UserId = input.UserId,
            Status = input.Status,
            StatusUpdatedAt = DateTime.UtcNow,
            MaxPaymentAttempts = input.MaxPaymentAttempts,
            EmailAddress = input.EmailAddress,
            BillingAddress = input.BillingAddress,
            Subtotal = input.Financials.Subtotal,
            TotalPrice = input.Financials.TotalPrice,
            TaxAmount = input.Financials.TaxAmount,
            Shipping = input.Shipping,
            _items = [..input.Items]
        };
    
    public Result IssueNewPayment(Payment payment)
    {
        if (!CanRetryPayment)
        {
            return OrderProblems.MaxPaymentAttempts;
        }
        
        ActivePayment?.Revoke();
        _payments.Add(payment);
        
        return Result.Ok();
    }
}