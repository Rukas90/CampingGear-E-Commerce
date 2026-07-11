using FastEndpoints;
using TrailStore.Basket.Api.Extensions;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Queries.GetSessionSummary;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Basket.Api.Endpoints.GetSessionSummary;

public sealed class GetSessionSummaryEndpoint(
    GetSessionSummaryQueryHandler query,
    CartCookieService cartCookieService)
    : EndpointWithoutRequest<SessionSummaryResponse>
{
    public override void Configure()
    {
        Get("/api/v1/session/summary");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await query.Handle(
            new GetSessionSummaryQuery(HttpContext.GetCartSessionContext()), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var summary = result.Value;
        
        if (summary.CartId is not null 
            && !summary.CartId.Equals(HttpContext.GetCartId()))
        {
            cartCookieService.UpdateCartId(summary.CartId.Value);
        }
        
        if (summary.CartId is null)
        {
            cartCookieService.ClearCartId();
        }

        await Send.OkAsync(new SessionSummaryResponse
        {
            CartCount = summary.CartCount,
            WishlistCount = summary.WishlistCount
        }, ct);
    }
}