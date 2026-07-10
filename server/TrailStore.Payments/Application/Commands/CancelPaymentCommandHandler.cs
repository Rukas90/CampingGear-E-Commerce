using Microsoft.Extensions.Logging;
using Stripe;
using TrailStore.Payments.Application.Abstractions;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Payments.Application.Commands;

[AppService<CancelPaymentCommandHandler>]
public sealed class CancelPaymentCommandHandler(
    IPaymentRepository paymentRepository, 
    ILogger<CancelPaymentCommandHandler> logger,
    IPaymentUnitOfWork unitOfWork,
    PaymentIntentService paymentIntentService)
    : ICommandHandler<CancelPaymentCommand>
{
    public async Task<Result> Handle(CancelPaymentCommand command, CancellationToken ct)
    {
        var payment = await paymentRepository.FindAsync(command.PaymentId, ct);

        if (payment is null)
        {
            logger.LogError("Could not cancel payment. The payment by id {PaymentId} was not found.", command.PaymentId);

            return PaymentProblems.NotFound;
        }
        
        payment.CancelAttempt();

        await unitOfWork.SaveAsync(ct);
        
        await paymentIntentService.CancelAsync(payment.IntentId, cancellationToken: ct);
        
        return Result.Ok();
    }
}