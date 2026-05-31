using FastEndpoints;
using TrailStore.Api.Checkout.Dto;
using TrailStore.Api.Common.Extensions;
using TrailStore.Api.Common.Mapping;
using TrailStore.Domain.Checkout.Interfaces;

namespace TrailStore.Api.Checkout.Endpoints;

public class UpdateShippingMethodEndpoint(ICheckoutService checkoutService) 
    : Endpoint<UpdateShippingMethodRequest, string>
{
    public override void Configure()
    {
        Patch("/api/v1/checkout/shipping-method");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateShippingMethodRequest req, CancellationToken ct)
    {
        var result = await checkoutService.UpdateCheckoutShippingMethod(
            HttpContext.GetShoppingContext(User), req.ShippingMethodId, ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        await Task.Delay((int)(4000 * Random.Shared.NextSingle()), ct); // TODO: REMOVE
        
        await Send.OkAsync("Success", ct);
    }
}