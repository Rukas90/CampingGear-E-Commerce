using FastEndpoints;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Queries.GetCart;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Api.Endpoints.GetCart;

public class GetCartEndpoint(
    GetCartQueryHandler query, ICartCookieService cartCookieService) 
    : EndpointWithoutRequest<CartItemResponse[]>
{
    public override void Configure()
    {
        Get("/api/v1/cart");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await query.Handle(
            new GetCartQuery(HttpContext.GetCartId(), Id<UserRef>.FromNullable(User.GetSubjectId())), ct);
        
        if (!result.IsSuccess)
        {
            result.OnError("cart.not_found", cartCookieService.ClearCart);
            
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