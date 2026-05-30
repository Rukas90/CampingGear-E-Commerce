using FastEndpoints;

namespace TrailStore.Api.Checkout.Endpoints;

public class ConfirmCheckoutEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/api/v1/checkout/confirm");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        
    }
}