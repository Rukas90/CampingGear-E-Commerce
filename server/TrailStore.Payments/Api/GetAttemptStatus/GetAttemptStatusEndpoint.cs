using FastEndpoints;
using TrailStore.Payments.Application.Queries;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Payments.Api.GetAttemptStatus;

public sealed class GetAttemptStatusEndpoint(GetPaymentAttemptStatusQueryHandler query)
    : Endpoint<GetAttemptStatusRequest, PaymentStatusResponse>
{
    public override void Configure()
    {
        Get("/api/v1/payments/attempts/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetAttemptStatusRequest req, CancellationToken ct)
    {
        var result = await query.Handle(new GetPaymentAttemptStatusQuery(Id<PaymentAttempt>.From(req.Id)), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        await Send.OkAsync(result.Value.ToResponse(), ct);
    }
}