using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Payments.Infrastructure.Payments;

[AppOptions("PaymentIntent")]
public class PaymentIntentOptions
{
    public required string ReferenceKey { get; init; }
}