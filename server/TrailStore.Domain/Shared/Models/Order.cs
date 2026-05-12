using TrailStore.Domain.Orders.Models;
using TrailStore.Domain.Shared.Enums;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Models;

public class Order : IModel<Order>
{
    public Id<Customer>? CustomerId { get; init; }
    public required OrderStatus Status { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required string EmailAddress { get; init; }
    public required PostalAddress ShippingAddress { get; init; }
    public required PostalAddress BillingAddress { get; init; }

    public Customer? Customer { get; private set; } = null;
    public ICollection<OrderItem> Items { get; private set; } = [];
    public required Id<Order> Id { get; init; }
}