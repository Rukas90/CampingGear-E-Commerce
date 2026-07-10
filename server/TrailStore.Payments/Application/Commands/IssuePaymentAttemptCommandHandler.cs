using TrailStore.Payments.Application.Abstractions;
using TrailStore.Payments.Application.Results;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Payments.Application.Commands;

[AppService<IssuePaymentAttemptCommandHandler>]
public sealed class IssuePaymentAttemptCommandHandler(
    IPaymentRepository paymentRepository, IPaymentUnitOfWork unitOfWork)
    : ICommandHandler<IssuePaymentAttemptCommand, PaymentAttemptResult>
{
    public async Task<Result<PaymentAttemptResult>> Handle(IssuePaymentAttemptCommand command, CancellationToken ct)
    {
        var payment = await paymentRepository.FindAsync(command.Id, ct);

        if (payment is null)
        {
            return PaymentProblems.NotFound;
        }

        if (payment.Status is PaymentStatus.Succeeded)
        {
            return PaymentProblems.PaymentAlreadyComplete;
        }

        if (payment.ActiveAttempt is not null)
        {
            return new PaymentAttemptResult
            {
                Id = payment.ActiveAttempt.Id
            };
        }
        
        var result = payment.BeginAttempt();

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        await unitOfWork.SaveAsync(ct);

        var newAttempt = result.Value;
        
        return new PaymentAttemptResult
        {
            Id = newAttempt.Id
        };
    }
}