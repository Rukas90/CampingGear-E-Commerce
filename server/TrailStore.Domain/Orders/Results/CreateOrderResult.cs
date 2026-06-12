using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Orders.Results;

public record CreateOrderResult(Id<Order> OrderId, string Token);