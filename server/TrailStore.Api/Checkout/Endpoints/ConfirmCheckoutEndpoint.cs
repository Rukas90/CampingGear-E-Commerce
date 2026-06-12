using FastEndpoints;
using TrailStore.Api.Checkout.Dto;
using TrailStore.Api.Common.Extensions;
using TrailStore.Api.Common.Mapping;
using TrailStore.Api.Orders.Endpoints;
using TrailStore.Domain.Checkout.Interfaces;

namespace TrailStore.Api.Checkout.Endpoints;

public class ConfirmCheckoutEndpoint(ICheckoutService checkoutService) 
    : EndpointWithoutRequest<CheckoutConfirmDto>
{
    public override void Configure()
    {
        Post("/api/v1/checkout/confirm");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await checkoutService.ConfirmCheckout(HttpContext.GetShoppingContext(User), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var token = result.Value.Token;
        
        await Send.CreatedAtAsync<GetOrderByTokenEndpoint>(
            routeValues: new { token },
            responseBody: new CheckoutConfirmDto { Token = result.Value.Token }, cancellation: ct);
    }
}