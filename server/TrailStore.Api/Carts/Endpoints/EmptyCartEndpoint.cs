using FastEndpoints;
using TrailStore.Api.Common.Extensions;
using TrailStore.Api.Common.Mapping;
using TrailStore.Api.Common.Services;
using TrailStore.Domain.Carts.Interfaces;

namespace TrailStore.Api.Carts.Endpoints;

public class EmptyCartEndpoint(
    ICartService cartService, ShoppingSessionCookieService shoppingSessionCookieService) 
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
        
        var result = await cartService.EmptyCart(ctx, ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            return;
        }

        shoppingSessionCookieService.SyncShoppingSession(ctx.SessionId, result.Value);
        
        await Send.OkAsync("Cart cleared successfully.", ct);
    }
}