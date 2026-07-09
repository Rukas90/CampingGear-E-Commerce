using Microsoft.EntityFrameworkCore;
using TrailStore.Payments.Application.Abstractions;
using TrailStore.Payments.Domain;
using TrailStore.Payments.Infrastructure.Database;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Payments.Infrastructure.Payments;

[AppService<IPaymentRepository>]
public sealed class PaymentRepository(PaymentDbContext _context) 
    : AggregateRepository<Payment, PaymentDbContext>(_context), IPaymentRepository
{
    public Task<Payment?> GetByReferenceId(Guid referenceId, CancellationToken ct)
        => AggregateWriteQuery.SingleOrDefaultAsync(payment => payment.ReferenceId == referenceId, ct);
}