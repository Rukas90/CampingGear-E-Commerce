namespace TrailStore.Ordering.Api.Endpoints.ConfirmCheckout;

public sealed class ConfirmCheckoutResponse
{
    public required string OrderToken { get; init; }
}