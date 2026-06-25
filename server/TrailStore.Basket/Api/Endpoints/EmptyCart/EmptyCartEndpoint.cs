using FastEndpoints;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Commands.EmptyCart;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Basket.Api.Endpoints.EmptyCart;

public sealed class EmptyCartEndpoint(
    EmptyCartCommandHandler command, ShoppingSessionCookieService shoppingSessionCookieService) 
    : EndpointWithoutRequest<string>
{
    public override void Configure()
    {
        Delete("/api/v1/cart");
        Throttle(5, 60);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var ctx = HttpContext.GetShoppingContext(User);
        
        var result = await command.Handle(new EmptyCartCommand(ctx), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            return;
        }

        shoppingSessionCookieService.SyncShoppingSession(ctx.SessionId, result.Value);
        
        await Send.OkAsync("Cart cleared successfully.", ct);
    }
}