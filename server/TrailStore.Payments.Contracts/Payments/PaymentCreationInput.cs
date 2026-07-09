namespace TrailStore.Payments.Contracts.Payments;

public sealed record PaymentCreationInput(Guid ReferenceId, decimal Amount, string CurrencyCode);