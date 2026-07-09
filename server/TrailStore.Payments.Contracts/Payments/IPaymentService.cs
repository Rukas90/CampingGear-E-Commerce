namespace TrailStore.Payments.Contracts.Payments;

public interface IPaymentService
{
    Task CreatePayment(PaymentCreationInput input, CancellationToken ct);
}