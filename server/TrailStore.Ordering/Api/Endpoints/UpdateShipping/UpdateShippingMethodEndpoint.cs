using FastEndpoints;
using TrailStore.Ordering.Api.ShoppingSession;
using TrailStore.Ordering.Application.Commands.UpdateShipping;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Ordering.Api.Endpoints.UpdateShipping;

public class UpdateShippingMethodEndpoint(UpdateShippingMethodCommandHandler command)
    : Endpoint<UpdateShippingMethodRequest, string>
{
    public override void Configure()
    {
        Patch("/api/v1/checkout/shipping-method");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(UpdateShippingMethodRequest req, CancellationToken ct)
    {
        var result = await command.Handle(
            new UpdateShippingMethodCommand(
                HttpContext.GetShoppingContext(User), 
                req.ShippingMethodId), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        await Send.OkAsync("Success", ct);
    }
}