using FastEndpoints;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Commands.DeleteFromCart;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Api.Endpoints.DeleteFromCart;

public sealed class DeleteFromCartEndpoint(
    DeleteFromCartCommandHandler command, ICartCookieService cartCookieService) 
    : Endpoint<DeleteFromCartRequest, string>
{
    public override void Configure()
    {
        Delete("/api/v1/cart/item");
        Throttle(20, 30);
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(DeleteFromCartRequest req, CancellationToken ct)
    {
        var result = await command.Handle(new DeleteFromCartCommand(
            HttpContext.GetCartId(), Id<UserRef>.FromNullable(User.GetSubjectId()), req.ItemId), ct);

        if (!result.IsSuccess)
        {
            result.OnError("cart.not_found", cartCookieService.ClearCart);
            
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        cartCookieService.SyncCart(result.Value);
        
        await Send.OkAsync("Cart item removed successfully.", ct);
    }
}