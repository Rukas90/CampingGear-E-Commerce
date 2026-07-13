using FastEndpoints;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Commands.AddToCart;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Api.Endpoints.AddToCart;

public sealed class AddToCartEndpoint(
    AddToCartCommandHandler command, ICartCookieService cartCookieService) 
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
            HttpContext.GetCartId(), Id<UserRef>.FromNullable(User.GetSubjectId()), req.SkuId, req.Quantity), ct);

        if (!result.IsSuccess)
        {
            result.OnError("cart.not_found", cartCookieService.ClearCart);
            
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        cartCookieService.SyncCart(result.Value);

        await Send.OkAsync("Cart item added successfully.", ct);
    }
}