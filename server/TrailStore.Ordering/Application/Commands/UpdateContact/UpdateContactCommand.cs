using TrailStore.Basket.Contracts.Session;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Ordering.Application.Commands.UpdateContact;

public sealed record UpdateContactCommand(
    ShoppingContextRef Ctx, CheckoutContact Data) : ICommand;