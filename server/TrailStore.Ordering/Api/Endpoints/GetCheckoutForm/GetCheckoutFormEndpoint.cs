using FastEndpoints;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Api.Extensions;
using TrailStore.Ordering.Api.PreProcessors;
using TrailStore.Ordering.Application.Queries.GetCheckoutForm;
using TrailStore.Shared.Api.Extensions;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Api.Endpoints.GetCheckoutForm;

public sealed class GetCheckoutFormEndpoint(GetCheckoutFormQueryHandler query) 
    : EndpointWithoutRequest<CheckoutFormResponse>
{
    public override void Configure()
    {
        Get("/api/v1/checkout/form");
        AllowAnonymous();
        PreProcessor<RequireCartId<EmptyRequest>>();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await query.Handle(
            new GetCheckoutFormQuery(HttpContext.GetCartId()!.Value, Id<UserRef>.FromNullable(User.GetSubjectId())), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var form = result.Value;

        await Send.OkAsync(form.ToResponse(), ct);
    }
}