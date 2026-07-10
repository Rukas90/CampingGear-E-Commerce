using TrailStore.Payments.Domain;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Payments.Application.Commands;

public sealed record CancelPaymentCommand(Id<Payment> PaymentId) : ICommand;