using FastEndpoints;
using TrailStore.Ordering.Api.Checkouts;
using TrailStore.Ordering.Api.Common.PostalAddress;
using TrailStore.Ordering.Api.ShoppingSession;
using TrailStore.Ordering.Application.Commands.UpdateShipping;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Ordering.Api.Endpoints.UpdateShipping;

public sealed class UpdateShippingAddressEndpoint(UpdateShippingAddressCommandHandler command)
    : Endpoint<PostalAddressRequest, CheckoutShippingResponse>
{
    public override void Configure()
    {
        Patch("/api/v1/checkout/shipping-address");
        AllowAnonymous();
    }

    public override async Task HandleAsync(PostalAddressRequest req, CancellationToken ct)
    {
        var result = await command.Handle
        (new UpdateShippingAddressCommand(
            HttpContext.GetShoppingContext(User), 
            new ShippingAddress(req.ToPostalAddress())), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        await Send.OkAsync(result.Value.ToResponse(), ct);
    }
}