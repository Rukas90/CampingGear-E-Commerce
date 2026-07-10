using TrailStore.Payments.Application.Results;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Payments.Application.Queries;

public sealed record GetPaymentQuery(Guid ReferenceId) : IQuery<PaymentResult>;