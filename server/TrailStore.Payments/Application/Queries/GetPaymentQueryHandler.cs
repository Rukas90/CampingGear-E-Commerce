using Stripe;
using TrailStore.Payments.Application.Abstractions;
using TrailStore.Payments.Application.Results;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Payments.Application.Queries;

[AppService<GetPaymentQueryHandler>]
public sealed class GetPaymentQueryHandler(
    IPaymentRepository paymentRepository,
    PaymentIntentService paymentIntentService)
    : IQueryHandler<GetPaymentQuery, PaymentResult>
{
    public async Task<Result<PaymentResult>> Handle(GetPaymentQuery query, CancellationToken ct)
    {
        var payment = await paymentRepository.FindByReferenceId(query.ReferenceId, ct);

        if (payment is null)
        {
            return PaymentProblems.NotFound;
        }

        var intent = await paymentIntentService.GetAsync(payment.IntentId, cancellationToken: ct);

        if (intent is null)
        {
            return PaymentProblems.NotFound;
        }
        
        return new PaymentResult
        {
            Id = payment.Id,
            ClientSecret = intent.ClientSecret,
            IsComplete = payment.Status is PaymentStatus.Succeeded,
            AttemptsRemaining = payment.AttemptsRemaining
        };
    }
}