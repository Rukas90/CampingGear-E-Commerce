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
    
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }

    private readonly List<PaymentAttempt> _attempts = [];
    public IReadOnlyList<PaymentAttempt> Attempts => _attempts;

    private PaymentAttempt? ActiveAttempt =>
        _attempts.SingleOrDefault(attempt => attempt.Status is PaymentStatus.Pending);
    
    public static Payment Create(PaymentCreationInput input, string intentId)
        => new()
        {
            Id = Id<Payment>.New(),
            ReferenceId = input.ReferenceId,
            IntentId = intentId,
            Amount = input.Amount,
            CurrencyCode = input.CurrencyCode,
            CreatedAt = DateTime.UtcNow
        };

    public void BeginAttempt()
    {
        if (ActiveAttempt is not null)
        {
            // Return error
            return;
        }
        
        var newAttempt = PaymentAttempt.Create();
        _attempts.Add(newAttempt);
    }
    
    public void ConfirmAttempt()
    {
        if (ActiveAttempt is null)
        {
            // Return error
            return;
        }
        
        ActiveAttempt.SetAsSucceeded();
        
        RaiseDomainEvent(new PaymentConfirmedDomainEvent(Id, ReferenceId));
    }
    
    public void CancelAttempt()
    {
        if (ActiveAttempt is null)
        {
            // Return error
            return;
        }
        
        ActiveAttempt.SetAsCanceled();
        
        RaiseDomainEvent(new PaymentCanceledDomainEvent(Id, ReferenceId));
    }
    
    public void FailAttempt()
    {
        if (ActiveAttempt is null)
        {
            // Return error
            return;
        }
        
        ActiveAttempt.SetAsFailed();
        
        RaiseDomainEvent(new PaymentFailedDomainEvent(Id, ReferenceId));
    }
}