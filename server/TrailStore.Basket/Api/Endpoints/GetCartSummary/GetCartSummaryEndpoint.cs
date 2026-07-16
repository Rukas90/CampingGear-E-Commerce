using FastEndpoints;
using TrailStore.Basket.Api.Extensions;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Queries.GetCartSummary;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Basket.Api.Endpoints.GetCartSummary;

public sealed class GetCartSummaryEndpoint(
    GetCartSummaryQueryHandler query,
    ICartCookieService cartCookieService)
    : EndpointWithoutRequest<CartSummaryResponse>
{
    public override void Configure()
    {
        Get("/api/v1/cart/summary");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await query.Handle(
            new GetCartSummaryQuery(HttpContext.GetCartSessionContext()), ct);

        if (!result.IsSuccess)
        {
            result.OnError("cart.not_found", cartCookieService.ClearCart);
            
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var summary = result.Value;
        
        if (summary.CartId is not null 
            && !summary.CartId.Equals(HttpContext.GetCartId()))
        {
            cartCookieService.UpdateCart(summary.CartId.Value);
        }
        
        if (summary.CartId is null)
        {
            cartCookieService.ClearCart();
        }

        await Send.OkAsync(new CartSummaryResponse
        {
            Count = summary.ItemsCount
        }, ct);
    }
}