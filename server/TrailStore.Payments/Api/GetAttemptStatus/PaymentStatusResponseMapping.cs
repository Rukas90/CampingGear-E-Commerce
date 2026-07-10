using TrailStore.Payments.Application.Results;

namespace TrailStore.Payments.Api.GetAttemptStatus;

public static class PaymentStatusResponseMapping
{
    public static PaymentStatusResponse ToResponse(this PaymentAttemptStatusResult attempt)
        => new()
        {
            Status = attempt.Status
        };
}