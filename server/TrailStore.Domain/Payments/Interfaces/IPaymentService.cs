using Stripe;
using TrailStore.Domain.Payments.Models;

namespace TrailStore.Domain.Payments.Interfaces;

public interface IPaymentService
{
    Task<PaymentIntent> CreateIntent(PaymentIntentCreateData data, CancellationToken ct);
}