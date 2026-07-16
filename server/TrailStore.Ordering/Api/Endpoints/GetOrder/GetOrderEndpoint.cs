using FastEndpoints;
using TrailStore.Ordering.Api.Orders;
using TrailStore.Ordering.Application.Queries.GetOrder;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Domain.Common;
using Order = TrailStore.Ordering.Domain.Orders.Order;

namespace TrailStore.Ordering.Api.Endpoints.GetOrder;

public sealed class GetOrderEndpoint(GetOrderQueryHandler query)
    : Endpoint<GetOrderRequest, OrderDetailsResponse>
{
    public override void Configure()
    {
        Get("/api/v1/orders/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetOrderRequest req, CancellationToken ct)
    {
        var result = await query.Handle(new GetOrderQuery(Id<Order>.From(req.Id)), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var summary = result.Value;

        await Send.OkAsync(summary.ToResponse(), ct);
    }
}