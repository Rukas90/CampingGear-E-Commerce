using TrailStore.Payments.Application.Results;

namespace TrailStore.Payments.Api.GetPayment;

public static class PaymentResponseMapping
{
    public static PaymentResponse ToResponse(this PaymentResult payment)
        => new()
        {
            PaymentId = payment.Id,
            ClientSecret = payment.ClientSecret,
            IsComplete = payment.IsComplete,
            AttemptsRemaining = payment.AttemptsRemaining
        };
}