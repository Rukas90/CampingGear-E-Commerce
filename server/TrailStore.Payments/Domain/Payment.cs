using TrailStore.Payments.Contracts.Payments;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Payments.Domain;

public class Payment : AggregateRoot<Payment>, IEntityCreatable, IEntityExpirable
{
    public required Guid ReferenceId  { get; init; }
    public required string IntentId { get; init; }
    public required decimal Amount { get; init; }
    public required string CurrencyCode { get; init; }
    public required int MaxAttempts { get; init; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }

    private readonly List<PaymentAttempt> _attempts = [];
    public IReadOnlyList<PaymentAttempt> Attempts => _attempts;
    
    public PaymentAttempt? ActiveAttempt =>
        _attempts.SingleOrDefault(attempt => attempt.Status is PaymentStatus.Pending);
    
    public int AttemptsRemaining => Math.Max(MaxAttempts - Attempts.Count, 0);
    
    public bool IsComplete => Attempts.SingleOrDefault(attempt => attempt.Status is PaymentStatus.Succeeded) is not null;
    
    public static Payment Create(PaymentCreationInput input, string intentId)
        => new()
        {
            Id = Id<Payment>.New(),
            ReferenceId = input.ReferenceId,
            IntentId = intentId,
            Amount = input.Amount,
            CurrencyCode = input.CurrencyCode,
            MaxAttempts = input.MaxAttempts,
            CreatedAt = DateTime.UtcNow
        };

    public Result<PaymentAttempt> BeginAttempt()
    {
        if (IsComplete)
        {
            return PaymentProblems.PaymentAlreadyComplete;
        }
        
        if (ActiveAttempt is not null)
        {
            return PaymentProblems.PaymentAlreadyHasAttempt;
        }
        
        var newAttempt = PaymentAttempt.Create();
        _attempts.Add(newAttempt);

        return newAttempt;
    }
    
    public void ConfirmAttempt()
    {
        if (ActiveAttempt is null)
        {
            Console.WriteLine("No Active attempt");

            return;
        }
        
        ActiveAttempt.SetAsSucceeded();
        
        Console.WriteLine("Payment confirmed");
        
        RaiseDomainEvent(new PaymentConfirmedDomainEvent(Id, ReferenceId));
    }
    
    public void CancelAttempt()
    {
        if (ActiveAttempt is null)
        {
            Console.WriteLine("No Active attempt");

            return;
        }
        
        Console.WriteLine("Payment canceled");
        
        ActiveAttempt.SetAsCanceled();
        
        RaiseDomainEvent(new PaymentCanceledDomainEvent(Id, ReferenceId));
    }
    
    public void FailAttempt()
    {
        if (ActiveAttempt is null)
        {
            Console.WriteLine("No Active attempt");

            return;
        }
        
        Console.WriteLine("Payment failed");
        
        ActiveAttempt.SetAsFailed();
        
        RaiseDomainEvent(new PaymentFailedDomainEvent(Id, ReferenceId));
    }
}