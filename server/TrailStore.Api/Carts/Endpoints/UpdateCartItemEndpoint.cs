using FastEndpoints;
using TrailStore.Api.Carts.Dto;
using TrailStore.Api.Carts.Mapping;
using TrailStore.Api.Common.Extensions;
using TrailStore.Api.Common.Mapping;
using TrailStore.Api.Common.Services;
using TrailStore.Domain.Carts.Interfaces;

namespace TrailStore.Api.Carts.Endpoints;

public class UpdateCartItemEndpoint(
    ICartService cartService, ShoppingSessionCookieService shoppingSessionCookieService) 
    : Endpoint<CartItemUpdateRequest, string>
{
    public override void Configure()
    {
        Put("/api/v1/cart/item");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CartItemUpdateRequest req, CancellationToken ct)
    {
        var ctx = HttpContext.GetShoppingContext(User);
        
        var result = await cartService.UpdateCartItem(req.ToLineItem(), ctx, ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            return;
        }

        shoppingSessionCookieService.SyncShoppingSession(ctx.SessionId, result.Value);
        
        await Send.OkAsync("Cart item updated successfully.", ct);
    }
}