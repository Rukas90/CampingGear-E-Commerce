using TrailStore.Payments.Application.Results;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Payments.Application.Commands;

public sealed record IssuePaymentAttemptCommand(Id<Payment> Id) : ICommand<PaymentAttemptResult>;