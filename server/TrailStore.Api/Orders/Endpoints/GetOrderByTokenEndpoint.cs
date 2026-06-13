using FastEndpoints;
using TrailStore.Api.Common.Mapping;
using TrailStore.Api.Orders.Dto;
using TrailStore.Api.Orders.Mapping;
using TrailStore.Domain.Orders.Interfaces;

namespace TrailStore.Api.Orders.Endpoints;

public class GetOrderByTokenEndpoint(IOrderService orderService) : Endpoint<GetOrderRequest, OrderDto>
{
    public override void Configure()
    {
        Get("/api/v1/orders/{token}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetOrderRequest req, CancellationToken ct)
    {
        var result = await orderService.GetOrderSummary(req.Token, ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        // bro... fix
        //await Send.OkAsync(result.Value, ct);
    }
}