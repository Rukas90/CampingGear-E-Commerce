using FastEndpoints;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Commands.UpdateCartItemQuantity;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Api.Endpoints.UpdateCartItemQuantity;

public sealed class UpdateCartItemQuantityEndpoint(
    UpdateCartItemQuantityCommandHandler command, ICartCookieService cartCookieService) 
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
            HttpContext.GetCartId(), Id<UserRef>.FromNullable(User.GetSubjectId()),
            req.ItemId, req.Quantity), ct);

        if (!result.IsSuccess)
        {
            result.OnError("cart.not_found", cartCookieService.ClearCart);
            
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        cartCookieService.SyncCart(result.Value);
        
        await Send.OkAsync("Cart item updated successfully.", ct);
    }
}