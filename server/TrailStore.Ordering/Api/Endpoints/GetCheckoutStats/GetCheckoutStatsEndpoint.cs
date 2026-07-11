using FastEndpoints;
using TrailStore.Ordering.Api.Extensions;
using TrailStore.Ordering.Api.PreProcessors;
using TrailStore.Ordering.Application.Queries.GetCheckoutStats;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Ordering.Api.Endpoints.GetCheckoutStats;

public sealed class GetCheckoutStatsEndpoint(GetCheckoutStatsQueryHandler query)
    : EndpointWithoutRequest<CheckoutStatsResponse>
{
    public override void Configure()
    {
        Get("/api/v1/checkout/stats");
        AllowAnonymous();
        PreProcessor<RequireCartId<EmptyRequest>>();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await query.Handle(
            new GetCheckoutStatsQuery(HttpContext.GetCartId()!.Value), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        await Send.OkAsync(result.Value.ToResponse(), ct);
    }
}