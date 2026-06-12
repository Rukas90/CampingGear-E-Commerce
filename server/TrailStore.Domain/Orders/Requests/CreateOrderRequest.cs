using TrailStore.Domain.Countries.Models;
using TrailStore.Domain.Orders.Models;
using TrailStore.Domain.Shared.Financials;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Orders.Requests;

public record CreateOrderRequest(
    Id<Customer>? CustomerId,
    string EmailAddress,
    ShippingAddress ShippingAddress,
    BillingAddress BillingAddress,
    ShippingMethod ShippingMethod,
    Country Country,
    IReadOnlyList<OrderLineItem> Items);