using TrailStore.Shared.Domain.Common;

namespace TrailStore.Payments.Contracts.Payments;

public interface IPaymentService
{
    Task<Result> CreatePayment(PaymentCreationInput input, CancellationToken ct);
}