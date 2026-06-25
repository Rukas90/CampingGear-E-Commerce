using FastEndpoints;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Queries.GetCart;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Basket.Api.Endpoints.GetCart;

public class GetCartEndpoint(
    GetCartQueryHandler query, ShoppingSessionCookieService shoppingSessionCookieService) 
    : EndpointWithoutRequest<CartItemResponse[]>
{
    public override void Configure()
    {
        Get("/api/v1/cart");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var ctx = HttpContext.GetShoppingContext(User);
        
        var result = await query.Handle(new GetCartQuery(ctx), ct);
        
        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var bag = result.Value;
        
        if (bag.SessionId is not null)
        {
            shoppingSessionCookieService.SyncShoppingSession(ctx.SessionId, bag.SessionId.Value);
        }

        await Send.OkAsync(bag.Items.ToResponses(), ct);
    }
}