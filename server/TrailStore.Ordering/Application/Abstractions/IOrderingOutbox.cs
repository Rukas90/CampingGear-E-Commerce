using TrailStore.Shared.Domain.Messages;
using TrailStore.Shared.Infrastructure.Outbox;

namespace TrailStore.Ordering.Application.Abstractions;

public interface IOrderingOutbox : IOutbox;