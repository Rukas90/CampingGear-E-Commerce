using Stripe;
using TrailStore.Domain.Carts.Models;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Domain.Orders.Interfaces;

public interface IOrderService
{
    Task<Result<Order>> ConfirmOrder(PaymentIntent intent, CartLineItem[] entries, CancellationToken ct);
}