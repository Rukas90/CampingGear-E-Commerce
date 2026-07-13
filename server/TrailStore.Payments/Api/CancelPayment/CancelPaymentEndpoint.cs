using FastEndpoints;
using TrailStore.Payments.Application.Commands;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Payments.Api.CancelPayment;

public sealed class CancelPaymentEndpoint(CancelPaymentCommandHandler command)
    : Endpoint<CancelPaymentRequest, string>
{
    public override void Configure()
    {
        Post("/api/v1/payments/cancel");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancelPaymentRequest req, CancellationToken ct)
    {
        var result = await command.Handle(new CancelPaymentCommand(Id<Payment>.From(req.PaymentId)), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        await Send.OkAsync("Payment has been canceled", ct);
    }
}