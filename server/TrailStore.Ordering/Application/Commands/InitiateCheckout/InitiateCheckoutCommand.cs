using TrailStore.Basket.Contracts.Session;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Ordering.Application.Commands.InitiateCheckout;

public sealed record InitiateCheckoutCommand(ShoppingContextRef Ctx) : ICommand;