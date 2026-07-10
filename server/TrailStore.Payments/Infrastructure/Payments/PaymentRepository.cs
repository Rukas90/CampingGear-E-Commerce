using Microsoft.EntityFrameworkCore;
using TrailStore.Payments.Application.Abstractions;
using TrailStore.Payments.Domain;
using TrailStore.Payments.Infrastructure.Database;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;
using TrailStore.Shared.Infrastructure.Persistence;

namespace TrailStore.Payments.Infrastructure.Payments;

[AppService<IPaymentRepository>]
public sealed class PaymentRepository(PaymentDbContext _context) 
    : AggregateRepository<Payment, PaymentDbContext>(_context), IPaymentRepository
{
    public async Task<PaymentAttempt?> FindAttempt(Id<PaymentAttempt> attemptId, CancellationToken ct)
    {
        var payment = await AggregateReadQuery
            .SingleOrDefaultAsync(payment => payment.Attempts.Any(a => a.Id == attemptId), ct);

        return payment?.Attempts.SingleOrDefault(a => a.Id == attemptId);
    }

    public Task<Payment?> FindByReferenceId(Guid referenceId, CancellationToken ct)
        => AggregateWriteQuery.SingleOrDefaultAsync(payment => payment.ReferenceId == referenceId, ct);

    protected override IQueryable<Payment> BuildAggregateQuery(DbSet<Payment> set)
        => set.Include(payment => payment.Attempts);
}