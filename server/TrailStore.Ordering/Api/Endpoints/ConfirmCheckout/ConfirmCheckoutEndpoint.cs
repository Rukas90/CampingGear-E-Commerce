using FastEndpoints;
using TrailStore.Ordering.Api.ShoppingSession;
using TrailStore.Ordering.Application.Commands.ConfirmCheckout;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Ordering.Api.Endpoints.ConfirmCheckout;

public sealed class ConfirmCheckoutEndpoint(ConfirmCheckoutCommandHandler command) 
    : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/api/v1/checkout/confirm");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await command.Handle(new ConfirmCheckoutCommand(HttpContext.GetShoppingContext(User)), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        await Send.OkAsync(new ConfirmCheckoutResponse
        {
            OrderToken = result.Value.OrderToken
        }, ct);
    }
}