using FastEndpoints;
using TrailStore.Api.Checkout.Dto;
using TrailStore.Api.Checkout.Mapping;
using TrailStore.Api.Common.Extensions;
using TrailStore.Api.Common.Mapping;
using TrailStore.Domain.Checkout.Interfaces;

namespace TrailStore.Api.Checkout.Endpoints;

public class GetCheckoutStatsEndpoint(ICheckoutService checkoutService) 
    : EndpointWithoutRequest<CheckoutStatsDto>
{
    public override void Configure()
    {
        Get("/api/v1/checkout/stats");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await checkoutService.GetCheckoutStats(HttpContext.GetShoppingContext(User), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        await Send.OkAsync(result.Value.ToDto(), ct);
    }
}