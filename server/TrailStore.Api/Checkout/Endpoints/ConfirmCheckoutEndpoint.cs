using FastEndpoints;
using TrailStore.Api.Checkout.Dto;
using TrailStore.Api.Common.Extensions;
using TrailStore.Api.Common.Mapping;
using TrailStore.Domain.Checkout.Interfaces;

namespace TrailStore.Api.Checkout.Endpoints;

public class ConfirmCheckoutEndpoint(ICheckoutService checkoutService) 
    : EndpointWithoutRequest<CheckoutConfirmDto>
{
    public override void Configure()
    {
        Post("/api/v1/checkout/confirm");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await checkoutService.ConfirmCheckout(HttpContext.GetShoppingContext(User), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        await Send.OkAsync(new CheckoutConfirmDto { OrderToken = result.Value.Token }, ct);
    }
}