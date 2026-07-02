using FastEndpoints;
using TrailStore.Ordering.Application.Queries.GetOrder;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Ordering.Api.Endpoints.GetOrder;

public sealed class GetOrderEndpoint(GetOrderQueryHandler query)
    : Endpoint<GetOrderRequest, OrderSummaryResponse>
{
    public override void Configure()
    {
        Get("/api/v1/orders/{token}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetOrderRequest req, CancellationToken ct)
    {
        var result = await query.Handle(new GetOrderQuery(req.Token), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var summary = result.Value;

        await Send.OkAsync(summary.ToResponse(), ct);
    }
}