using FastEndpoints;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Commands.AddToCart;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Basket.Api.Endpoints.AddToCart;

public sealed class AddToCartEndpoint(
    AddToCartCommandHandler command, CartCookieService cartCookieService) 
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
        
        var result = await command.Handle(new AddToCartCommand(
            HttpContext.GetCartId(), User.GetId(), req.SkuId, req.Quantity), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        cartCookieService.SyncCart(result.Value);

        await Send.OkAsync("Cart item added successfully.", ct);
    }
}