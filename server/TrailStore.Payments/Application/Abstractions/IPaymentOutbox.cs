using TrailStore.Shared.Domain.Messages;
using TrailStore.Shared.Infrastructure.Outbox;

namespace TrailStore.Payments.Application.Abstractions;

public interface IPaymentOutbox : IOutbox;