using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.ShoppingSessions.Models;

public record ShoppingContext(Id<Customer>? CustomerId, Id<ShoppingSession>? SessionId)
{
    public bool Invalid => CustomerId is null && SessionId is null;
}