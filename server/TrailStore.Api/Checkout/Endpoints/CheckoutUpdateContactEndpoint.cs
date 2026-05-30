using FastEndpoints;
using TrailStore.Api.Checkout.Dto;
using TrailStore.Api.Checkout.Mapping;
using TrailStore.Api.Common.Extensions;
using TrailStore.Api.Common.Mapping;
using TrailStore.Domain.Checkout.Interfaces;

namespace TrailStore.Api.Checkout.Endpoints;

public class CheckoutUpdateContactEndpoint(ICheckoutService checkoutService)
    : Endpoint<CheckoutContactRequest, string>
{
    public override void Configure()
    {
        Patch("/api/v1/checkout/contact");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CheckoutContactRequest req, CancellationToken ct)
    {
        var result = await checkoutService.UpdateCheckoutContact(
            HttpContext.GetShoppingContext(User), req.ToContact(), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        await Send.OkAsync("Success", ct);
    }
}