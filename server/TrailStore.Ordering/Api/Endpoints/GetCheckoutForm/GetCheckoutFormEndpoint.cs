using FastEndpoints;
using TrailStore.Ordering.Api.ShoppingSession;
using TrailStore.Ordering.Application.Queries.GetCheckoutForm;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Ordering.Api.Endpoints.GetCheckoutForm;

public sealed class GetCheckoutFormEndpoint(GetCheckoutFormQueryHandler query) 
    : EndpointWithoutRequest<CheckoutFormResponse>
{
    public override void Configure()
    {
        Get("/api/v1/checkout/form");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await query.Handle(
            new GetCheckoutFormQuery(HttpContext.GetShoppingContext(User)), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var form = result.Value;

        await Send.OkAsync(form.ToResponse(), ct);
    }
}