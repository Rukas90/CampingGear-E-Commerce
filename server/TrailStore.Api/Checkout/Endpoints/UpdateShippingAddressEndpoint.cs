using FastEndpoints;
using TrailStore.Api.Checkout.Dto;
using TrailStore.Api.Checkout.Mapping;
using TrailStore.Api.Common.Dto;
using TrailStore.Api.Common.Extensions;
using TrailStore.Api.Common.Mapping;
using TrailStore.Domain.Checkout.Interfaces;

namespace TrailStore.Api.Checkout.Endpoints;

public class UpdateShippingAddressEndpoint(ICheckoutService checkoutService) 
    : Endpoint<PostalAddressRequest, CheckoutShippingDto>
{
    public override void Configure()
    {
        Patch("/api/v1/checkout/shipping-address");
        AllowAnonymous();
    }

    public override async Task HandleAsync(PostalAddressRequest req, CancellationToken ct)
    {
        var result = await checkoutService.UpdateCheckoutShippingAddress(
            HttpContext.GetShoppingContext(User), req.ToPostalAddress(), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        await Task.Delay((int)(4000 * Random.Shared.NextSingle()), ct); // TODO: REMOVE
        
        await Send.OkAsync(result.Value.ToDto(), ct);
    }
}