using FastEndpoints;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Commands.UpdateCartItemQuantity;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Basket.Api.Endpoints.UpdateCartItemQuantity;

public sealed class UpdateCartItemQuantityEndpoint(
    UpdateCartItemQuantityCommandHandler command, CartCookieService cartCookieService) 
    : Endpoint<UpdateCartItemQuantityRequest, string>
{
    public override void Configure()
    {
        Put("/api/v1/cart/item");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateCartItemQuantityRequest req, CancellationToken ct)
    {
        var result = await command.Handle(new UpdateCartItemQuantityCommand(
            HttpContext.GetCartId(), User.GetId(), req.ItemId, req.Quantity), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        cartCookieService.SyncCart(result.Value);
        
        await Send.OkAsync("Cart item updated successfully.", ct);
    }
}