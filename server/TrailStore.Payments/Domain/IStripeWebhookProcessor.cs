using Stripe;

namespace TrailStore.Payments.Domain;

public interface IStripeWebhookProcessor
{
    Task ProcessEvent(Event evt, CancellationToken ct);
}