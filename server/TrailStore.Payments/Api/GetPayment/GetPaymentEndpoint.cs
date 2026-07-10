using FastEndpoints;
using TrailStore.Payments.Application.Queries;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Payments.Api.GetPayment;

public sealed class GetPaymentEndpoint(GetPaymentQueryHandler query)
    : Endpoint<GetPaymentRequest, PaymentResponse>
{
    public override void Configure()
    {
        Get("/api/v1/payments/{referenceId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetPaymentRequest req, CancellationToken ct)
    {
        var result = await query.Handle(new GetPaymentQuery(req.ReferenceId), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        await Send.OkAsync(result.Value.ToResponse(), ct);
    }
}