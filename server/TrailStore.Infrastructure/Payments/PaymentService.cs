using TrailStore.Domain.Payments.Interfaces;
using TrailStore.Shared.Common;
using Stripe;
using TrailStore.Domain.Payments.Models;

namespace TrailStore.Infrastructure.Payments;

[AppService<IPaymentService>]
public class PaymentService(
    PaymentIntentService paymentIntentService) 
    : IPaymentService
{
    public async Task<PaymentIntent> CreateIntent(PaymentIntentCreateData data, CancellationToken ct)
    {
        return await paymentIntentService.CreateAsync(new PaymentIntentCreateOptions
        {
            Amount = (long)(data.Amount * 100), // In Cents
            Currency = "eur",
            Metadata = new Dictionary<string, string>
            {
                { "order_id", data.OrderId.ToString() }
            }
        }, cancellationToken: ct);
    }
}