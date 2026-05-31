using FastEndpoints;
using TrailStore.Api.Checkout.Dto;
using TrailStore.Api.Checkout.Mapping;
using TrailStore.Api.Common.Extensions;
using TrailStore.Api.Common.Mapping;
using TrailStore.Domain.Checkout.Interfaces;

namespace TrailStore.Api.Checkout.Endpoints;

public class UpdateBillingEndpoint(ICheckoutService checkoutService) 
    : Endpoint<UpdateBillingRequest, string>
{
    public override void Configure()
    {
        Patch("/api/v1/checkout/billing");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateBillingRequest req, CancellationToken ct)
    {
        var result = await checkoutService.UpdateCheckoutBilling(
            HttpContext.GetShoppingContext(User), req.ToBilling(), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        await Send.OkAsync("Success", ct);
    }
}