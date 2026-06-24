using FastEndpoints;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Commands.AddToCart;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Basket.Api.Endpoints;

public class AddToCartEndpoint(
    AddToCartCommandHandler command, ShoppingSessionCookieService shoppingSessionCookieService) 
    : Endpoint<AddToCartRequest, string>
{
    public override void Configure()
    {
        Post("/api/v1/cart/item");
        Throttle(20, 30); 
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddToCartRequest req, CancellationToken ct)
    {
        var ctx = HttpContext.GetShoppingContext(User);
        
        var result = await command.Handle(new AddToCartCommand(ctx, req.SkuId, req.Quantity), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        shoppingSessionCookieService.SyncShoppingSession(ctx.SessionId, result.Value);

        await Send.OkAsync("Cart item added successfully.", ct);
    }
}