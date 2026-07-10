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
    
    public PaymentStatus Status { get; private set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }

    private readonly List<PaymentAttempt> _attempts = [];
    public IReadOnlyList<PaymentAttempt> Attempts => _attempts;
    
    public PaymentAttempt? ActiveAttempt =>
        _attempts.SingleOrDefault(attempt => attempt.Status is PaymentStatus.Pending);
    
    public int AttemptsRemaining => Math.Max(MaxAttempts - Attempts.Count, 0);
    
    public static Payment Create(PaymentCreationInput input, string intentId)
        => new()
        {
            Id = Id<Payment>.New(),
            ReferenceId = input.ReferenceId,
            IntentId = intentId,
            Amount = input.Amount,
            CurrencyCode = input.CurrencyCode,
            MaxAttempts = input.MaxAttempts,
            CreatedAt = DateTime.UtcNow,
            Status = PaymentStatus.Pending
        };

    public Result<PaymentAttempt> BeginAttempt()
    {
        if (Status is PaymentStatus.Succeeded)
        {
            return PaymentProblems.PaymentAlreadyComplete;
        }
        
        if (ActiveAttempt is not null)
        {
            return PaymentProblems.PaymentAlreadyHasAttempt;
        }
        
        if (Status is PaymentStatus.Canceled)
        {
            return PaymentProblems.PaymentCanceled;
        }
        
        if (AttemptsRemaining <= 0)
        {
            return PaymentProblems.OutOfAttempts;
        }
        
        var newAttempt = PaymentAttempt.Create(Id);
        _attempts.Add(newAttempt);

        return newAttempt;
    }
    
    public void ConfirmAttempt()
    {
        if (ActiveAttempt is null)
        {
            return;
        }
        
        ActiveAttempt.SetAsSucceeded();

        Status = PaymentStatus.Succeeded;
        
        RaiseDomainEvent(new PaymentConfirmedDomainEvent(Id, ReferenceId));
    }
    
    public void CancelAttempt()
    {
        ActiveAttempt?.SetAsCanceled();
        
        Status = PaymentStatus.Canceled;
        
        RaiseDomainEvent(new PaymentCanceledDomainEvent(ReferenceId));
    }
    
    public void FailAttempt()
    {
        if (ActiveAttempt is null)
        {
            return;
        }
        
        ActiveAttempt.SetAsFailed();

        if (AttemptsRemaining <= 0)
        {
            Status = PaymentStatus.Failed;
            
            RaiseDomainEvent(new PaymentFailedDomainEvent(ReferenceId));
        }
    }
}