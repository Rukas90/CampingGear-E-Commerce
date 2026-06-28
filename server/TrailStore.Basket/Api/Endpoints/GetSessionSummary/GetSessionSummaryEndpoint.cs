using FastEndpoints;
using TrailStore.Basket.Api.Sessions;
using TrailStore.Basket.Application.Queries.GetSessionSummary;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Basket.Api.Endpoints.GetSessionSummary;

public sealed class GetSessionSummaryEndpoint(
    GetSessionSummaryQueryHandler query,
    ShoppingSessionCookieService shoppingSessionCookieService)
    : EndpointWithoutRequest<SessionSummaryResponse>
{
    public override void Configure()
    {
        Get("/api/v1/session/summary");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var ctx = HttpContext.GetShoppingContext(User);
        
        var result = await query.Handle(
            new GetSessionSummaryQuery(HttpContext.GetShoppingContext(User)), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var summary = result.Value;
        
        if (summary.Id is not null && !summary.Id.Equals(ctx.SessionId))
        {
            shoppingSessionCookieService.UpdateShoppingSessionId(summary.Id.Value);
        }
        
        if (summary.Id is null)
        {
            shoppingSessionCookieService.ClearShoppingSession();
        }

        await Send.OkAsync(new SessionSummaryResponse
        {
            CartCount = summary.CartCount,
            WishlistCount = summary.WishlistCount
        }, ct);
    }
}