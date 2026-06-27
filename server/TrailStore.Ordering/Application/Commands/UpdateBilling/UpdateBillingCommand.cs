using TrailStore.Basket.Contracts.Session;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Ordering.Application.Commands.UpdateBilling;

public sealed record UpdateBillingCommand(ShoppingContextRef Ctx, CheckoutBilling Data) : ICommand;