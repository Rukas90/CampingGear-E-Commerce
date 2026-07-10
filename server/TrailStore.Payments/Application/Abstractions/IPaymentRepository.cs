using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Payments.Application.Abstractions;

public interface IPaymentRepository : IAggregateRepository<Payment>
{
    Task<PaymentAttempt?> FindAttempt(Id<PaymentAttempt> attemptId, CancellationToken ct);
    
    Task<Payment?> FindByReferenceId(Guid referenceId, CancellationToken ct);
}