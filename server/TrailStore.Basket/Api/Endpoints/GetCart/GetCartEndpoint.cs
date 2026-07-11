using FastEndpoints;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Queries.GetCart;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Basket.Api.Endpoints.GetCart;

public class GetCartEndpoint(
    GetCartQueryHandler query, CartCookieService cartCookieService) 
    : EndpointWithoutRequest<CartItemResponse[]>
{
    public override void Configure()
    {
        Get("/api/v1/cart");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await query.Handle(new GetCartQuery(HttpContext.GetCartId(), User.GetId()), ct);
        
        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var cart = result.Value;
        
        if (cart.Id is not null)
        {
            cartCookieService.SyncCart(cart.Id.Value);
        }

        await Send.OkAsync(cart.Items.ToResponses(), ct);
    }
}