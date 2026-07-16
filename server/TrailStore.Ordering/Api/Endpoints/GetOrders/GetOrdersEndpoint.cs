using FastEndpoints;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Api.Orders;
using TrailStore.Ordering.Application.Queries.GetOrders;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Ordering.Api.Endpoints.GetOrders;

public sealed class GetOrdersEndpoint(GetOrdersQueryHandler query)
    : EndpointWithoutRequest<OrderSummaryResponse[]>
{
    public override void Configure()
    {
        Get("/api/v1/orders");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await query.Handle(new GetOrdersQuery(User.GetSubjectTypedId<UserRef>()), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var orders = result.Value;

        await Send.OkAsync(orders.ToResponses(), ct);
    }
}