using TrailStore.Payments.Application.Abstractions;
using TrailStore.Payments.Application.Results;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Payments.Application.Queries;

[AppService<GetPaymentAttemptStatusQueryHandler>]
public sealed class GetPaymentAttemptStatusQueryHandler(IPaymentRepository paymentRepository)
    : IQueryHandler<GetPaymentAttemptStatusQuery, PaymentAttemptStatusResult>
{
    public async Task<Result<PaymentAttemptStatusResult>> Handle(GetPaymentAttemptStatusQuery query, CancellationToken ct)
    {
        var paymentAttempt = await paymentRepository.FindAttempt(query.AttemptId, ct);

        if (paymentAttempt is null)
        {
            return PaymentProblems.NotFound;
        }

        return new PaymentAttemptStatusResult
        {
            Status = paymentAttempt.Status
        };
    }
}