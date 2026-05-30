using FastEndpoints;
using TrailStore.Api.Common.Extensions;
using TrailStore.Api.Common.Services;
using TrailStore.Api.Session.Dto;
using TrailStore.Api.Session.Mapping;
using TrailStore.Domain.ShoppingSessions.Interfaces;

namespace TrailStore.Api.Session.Endpoints;

public class GetSessionSummaryEndpoint(
    IShoppingSessionService shoppingSessionService, ShoppingSessionCookieService shoppingSessionCookieService) 
    : EndpointWithoutRequest<SessionSummaryDto>
{
    public override void Configure()
    {
        Get("/api/v1/session/summary");
        AllowAnonymous();
    }

    public override async Task<SessionSummaryDto> ExecuteAsync(CancellationToken ct)
    {
        var ctx = HttpContext.GetShoppingContext(User);
        
        var summary = await shoppingSessionService.GetSessionSummary(ctx, ct);

        if (summary.Id is not null && !summary.Id.Equals(ctx.SessionId))
        {
            shoppingSessionCookieService.UpdateShoppingSessionId(summary.Id.Value);
        }
        
        if (summary.Id is null)
        {
            HttpContext.ClearShoppingSessionId();
        }
        
        return summary.ToDto();
    }
}