using FastEndpoints;
using TrailStore.Api.Common.Extensions;
using TrailStore.Api.Common.Mapping;
using TrailStore.Domain.Checkout.Interfaces;

namespace TrailStore.Api.Checkout.Endpoints;

public class CheckoutEndpoint(ICheckoutSessionService checkoutSessionService) 
    : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/api/v1/checkout");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await checkoutSessionService.GetCreateCheckoutSession(
            HttpContext.GetShoppingContext(User), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        await Send.OkAsync("Ok", ct);
    }
}