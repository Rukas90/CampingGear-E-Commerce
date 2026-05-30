using FastEndpoints;
using TrailStore.Api.Carts.Dto;
using TrailStore.Api.Common.Extensions;
using TrailStore.Api.Common.Mapping;
using TrailStore.Api.Common.Services;
using TrailStore.Domain.Carts.Interfaces;

namespace TrailStore.Api.Carts.Endpoints;

public class DeleteFromCartEndpoint(
    ICartService cartService, ShoppingSessionCookieService shoppingSessionCookieService) 
    : Endpoint<DeleteItemFromCartRequest, string>
{
    public override void Configure()
    {
        Delete("/api/v1/cart/item");
        Throttle(20, 30);
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteItemFromCartRequest req, CancellationToken ct)
    {
        var ctx = HttpContext.GetShoppingContext(User);
        
        var result = await cartService.RemoveItemFromCart(req.Code, ctx, ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            return;
        }

        shoppingSessionCookieService.SyncShoppingSession(ctx.SessionId, result.Value);
        
        await Send.OkAsync("Cart item removed successfully.", ct);
    }
}