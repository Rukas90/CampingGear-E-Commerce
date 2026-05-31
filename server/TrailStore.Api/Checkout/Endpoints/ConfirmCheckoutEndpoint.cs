using FastEndpoints;
using TrailStore.Api.Checkout.Dto;

namespace TrailStore.Api.Checkout.Endpoints;

public class ConfirmCheckoutEndpoint : EndpointWithoutRequest<CheckoutConfirmDto>
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