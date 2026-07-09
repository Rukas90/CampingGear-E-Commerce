using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Payments.Application.Abstractions;

public interface IPaymentRepository : IAggregateRepository<Payment>
{
    Task<Payment?> GetByReferenceId(Guid referenceId, CancellationToken ct);
}