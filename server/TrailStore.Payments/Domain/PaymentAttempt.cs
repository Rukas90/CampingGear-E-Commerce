using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Payments.Domain;

public class PaymentAttempt : IModel<PaymentAttempt>
{
    public required Id<PaymentAttempt> Id { get; init; }
    public required Id<Payment> PaymentId { get; init; }
    public PaymentStatus Status { get; private set; }
    public DateTime UpdatedStatusAt { get; private set; }

    public static PaymentAttempt Create(Id<Payment> paymentId)
        => new()
        {
            Id = Id<PaymentAttempt>.New(),
            PaymentId = paymentId,
            Status = PaymentStatus.Pending,
            UpdatedStatusAt = DateTime.UtcNow
        };
    
    public void SetAsSucceeded()
        => SetStatus(PaymentStatus.Succeeded);

    public void SetAsCanceled()
        => SetStatus(PaymentStatus.Canceled);
    
    public void SetAsFailed()
        => SetStatus(PaymentStatus.Failed);

    private void SetStatus(PaymentStatus status)
    {
        Status = status;
        UpdatedStatusAt = DateTime.UtcNow;
    }
}