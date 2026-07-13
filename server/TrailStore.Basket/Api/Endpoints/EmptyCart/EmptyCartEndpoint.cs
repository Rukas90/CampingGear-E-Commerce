using FastEndpoints;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Commands.EmptyCart;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Api.Endpoints.EmptyCart;

public sealed class EmptyCartEndpoint(
    EmptyCartCommandHandler command, ICartCookieService cartCookieService) 
    : EndpointWithoutRequest<string>
{
    public override void Configure()
    {
        Delete("/api/v1/cart");
        Throttle(5, 60);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await command.Handle(
            new EmptyCartCommand(HttpContext.GetCartId(), Id<UserRef>.FromNullable(User.GetSubjectId())), ct);

        if (!result.IsSuccess)
        {
            result.OnError("cart.not_found", cartCookieService.ClearCart);
            
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        cartCookieService.SyncCart(result.Value);
        
        await Send.OkAsync("Cart cleared successfully.", ct);
    }
}