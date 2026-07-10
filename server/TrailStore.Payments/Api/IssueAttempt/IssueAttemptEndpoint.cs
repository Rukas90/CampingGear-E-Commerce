using FastEndpoints;
using TrailStore.Payments.Application.Commands;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Payments.Api.IssueAttempt;

public sealed class IssueAttemptEndpoint(IssuePaymentAttemptCommandHandler command)
    : Endpoint<IssueAttemptRequest, PaymentAttemptResponse>
{
    public override void Configure()
    {
        Post("/api/v1/payments/attempts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(IssueAttemptRequest req, CancellationToken ct)
    {
        var result = await command.Handle(new IssuePaymentAttemptCommand(req.PaymentId), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }

        var attempt = result.Value;
        
        await Send.OkAsync(new PaymentAttemptResponse
        {
            AttemptId = attempt.Id
        }, ct);
    }
}