using TrailStore.Payments.Application.Results;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Payments.Application.Queries;

public sealed record GetPaymentAttemptStatusQuery(Id<PaymentAttempt> AttemptId) : IQuery<PaymentAttemptStatusResult>;