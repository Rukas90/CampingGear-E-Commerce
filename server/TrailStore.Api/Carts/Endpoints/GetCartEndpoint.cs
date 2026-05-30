using FastEndpoints;
using TrailStore.Api.Carts.Dto;
using TrailStore.Api.Carts.Mapping;
using TrailStore.Api.Common.Extensions;
using TrailStore.Api.Common.Services;
using TrailStore.Domain.Carts.Interfaces;

namespace TrailStore.Api.Carts.Endpoints;

public class GetCartEndpoint(
    ICartService cartService, ShoppingSessionCookieService shoppingSessionCookieService) 
    : EndpointWithoutRequest<List<CartItemDto>>
{
    public override void Configure()
    {
        Get("/api/v1/cart");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var ctx = HttpContext.GetShoppingContext(User);
        
        var bag = await cartService.GetBag(ctx, selector: CartMappingSelectors.ToItemDto(), ct);
        
        if (bag.SessionId is not null)
        {
            shoppingSessionCookieService.SyncShoppingSession(ctx.SessionId, bag.SessionId.Value);
        }

        await Send.OkAsync(bag.Items, ct);
    }
}