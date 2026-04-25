using TrailStore.Domain.Enums;
using TrailStore.Domain.Orders;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Models;

public class Order : IModel<Order>
{
    public required Id<Order>     Id              { get; init; }
    public          Id<Customer>? CustomerId      { get; init; }
    public required OrderStatus   Status          { get; init; }
    public required DateTime      CreatedAt       { get; init; }
    public required string        EmailAddress    { get; init; }
    public required PostalAddress ShippingAddress { get; init; }
    public required PostalAddress BillingAddress  { get; init; }

    public Customer?              Customer { get; private set; } = null;
    public ICollection<OrderItem> Items    { get; private set; } = [];
}