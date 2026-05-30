using FastEndpoints;
using TrailStore.Api.Checkout.Dto;

namespace TrailStore.Api.Checkout.Endpoints;

public class GetCheckoutStatsEndpoint : EndpointWithoutRequest<CheckoutDto>
{
    public override void Configure()
    {
        Get("/api/v1/checkout");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        
    }
}