using FastEndpoints;
using TrailStore.Api.Common.Dto;
using TrailStore.Api.Common.Extensions;
using TrailStore.Api.Common.Mapping;
using TrailStore.Domain.Checkout.Interfaces;

namespace TrailStore.Api.Checkout.Endpoints;

public class CheckoutUpdateShippingEndpoint(ICheckoutService checkoutService) 
    : Endpoint<PostalAddressRequest, string>
{
    public override void Configure()
    {
        Patch("/api/v1/checkout/shipping");
        AllowAnonymous();
    }

    public override async Task HandleAsync(PostalAddressRequest req, CancellationToken ct)
    {
        var result = await checkoutService.UpdateCheckoutShipping(
            HttpContext.GetShoppingContext(User), req.ToPostalAddress(), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        await Task.Delay((int)(4000 * Random.Shared.NextSingle()), ct);
        
        await Send.OkAsync("Success", ct);
    }
}