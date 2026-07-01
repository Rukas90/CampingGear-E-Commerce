using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Domain.Financials;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Orders;

public sealed class OrderCreationInput
{
    public required Id<Order> Id { get; init; }
    public required string Token {  get; init; }
    public Id<UserRef>? UserId { get; init; }
    public required OrderStatus Status { get; init; }
    public required int MaxPaymentAttempts { get; init; }
    public required string EmailAddress { get; init; }
    public required BillingAddress BillingAddress { get; init; }
    public required OrderFinancials Financials { get; init; }
    public required OrderShipping Shipping { get; init; }
    public required OrderItem[] Items { get; init; }
}