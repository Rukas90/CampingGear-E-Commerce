namespace TrailStore.Ordering.Api.Endpoints.ConfirmCheckout;

public sealed class ConfirmCheckoutResponse
{
    public required Guid OrderId { get; init; }
}