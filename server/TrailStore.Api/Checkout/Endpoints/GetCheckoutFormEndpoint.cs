using FastEndpoints;
using TrailStore.Api.Checkout.Dto;
using TrailStore.Api.Checkout.Mapping;
using TrailStore.Api.Common.Extensions;
using TrailStore.Api.Common.Mapping;
using TrailStore.Domain.Checkout.Interfaces;

namespace TrailStore.Api.Checkout.Endpoints;

public class GetCheckoutFormEndpoint(ICheckoutService checkoutService) 
    : EndpointWithoutRequest<CheckoutFormDto>
{
    public override void Configure()
    {
        Get("/api/v1/checkout/form");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await checkoutService.GetCheckoutForm(HttpContext.GetShoppingContext(User), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var form = result.Value;

        await Send.OkAsync(form.ToDto(), ct);
    }
}