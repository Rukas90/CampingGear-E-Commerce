using FastEndpoints;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Commands.EmptyCart;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Basket.Api.Endpoints.EmptyCart;

public sealed class EmptyCartEndpoint(
    EmptyCartCommandHandler command, CartCookieService cartCookieService) 
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
        var result = await command.Handle(new EmptyCartCommand(HttpContext.GetCartId(), User.GetId()), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        cartCookieService.SyncCart(result.Value);
        
        await Send.OkAsync("Cart cleared successfully.", ct);
    }
}