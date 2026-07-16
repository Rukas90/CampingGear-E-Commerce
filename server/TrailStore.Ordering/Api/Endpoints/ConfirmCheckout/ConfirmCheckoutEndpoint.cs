using FastEndpoints;
using TrailStore.Ordering.Api.Extensions;
using TrailStore.Ordering.Api.PreProcessors;
using TrailStore.Ordering.Application.Commands.ConfirmCheckout;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Ordering.Api.Endpoints.ConfirmCheckout;

public sealed class ConfirmCheckoutEndpoint(ConfirmCheckoutCommandHandler command) 
    : Endpoint<CheckoutConfirmRequest, ConfirmCheckoutResponse>
{
    public override void Configure()
    {
        Post("/api/v1/checkout/confirm");
        AllowAnonymous();
        PreProcessor<RequireCartId<CheckoutConfirmRequest>>();
    }

    public override async Task HandleAsync(CheckoutConfirmRequest req, CancellationToken ct)
    {
        var result = await command.Handle(
            new ConfirmCheckoutCommand(req.SaveInformation, HttpContext.GetCartId()!.Value), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        await Send.OkAsync(new ConfirmCheckoutResponse
        {
            OrderId = result.Value.OrderId
        }, ct);
    }
}