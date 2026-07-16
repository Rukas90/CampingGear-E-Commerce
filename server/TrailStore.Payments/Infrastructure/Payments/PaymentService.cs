using Microsoft.Extensions.Options;
using Stripe;
using TrailStore.Payments.Application.Abstractions;
using TrailStore.Payments.Contracts.Payments;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Payments.Infrastructure.Payments;

[AppService<IPaymentService>]
public class PaymentService(
    IPaymentRepository paymentRepository,
    IOptions<PaymentIntentOptions> options,
    IPaymentUnitOfWork unitOfWork,
    PaymentIntentService paymentIntentService) : IPaymentService
{
    public async Task<Result> CreatePayment(PaymentCreationInput input, CancellationToken ct)
    {
        try
        {
            var intent = await paymentIntentService.CreateAsync(new PaymentIntentCreateOptions
            {
                Amount = (long)(input.Amount * 100m), // In Cents
                Currency = "eur",
                Metadata = new Dictionary<string, string>
                {
                    { options.Value.ReferenceKey, input.ReferenceId.ToString() }
                }
            }, cancellationToken: ct);

            paymentRepository.Add(Payment.Create(input, intent.Id));

            await unitOfWork.SaveAsync(ct);
            
            return Result.Ok();
        }
        catch (StripeException stripeException)
        {
            return PaymentProblems.StripeError(stripeException.StripeError.Message);
        }
    }
}