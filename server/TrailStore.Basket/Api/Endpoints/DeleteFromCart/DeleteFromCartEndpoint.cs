using FastEndpoints;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Commands.DeleteFromCart;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Basket.Api.Endpoints.DeleteFromCart;

public sealed class DeleteFromCartEndpoint(
    DeleteFromCartCommandHandler command, ShoppingSessionCookieService shoppingSessionCookieService) 
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
        var ctx = HttpContext.GetShoppingContext(User);
        
        var result = await command.Handle(new DeleteFromCartCommand(ctx, req.ItemId), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        shoppingSessionCookieService.SyncShoppingSession(ctx.SessionId, result.Value);
        
        await Send.OkAsync("Cart item removed successfully.", ct);
    }
}