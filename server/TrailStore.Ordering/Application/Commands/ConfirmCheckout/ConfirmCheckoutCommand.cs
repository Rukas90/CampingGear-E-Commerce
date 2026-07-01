using TrailStore.Basket.Contracts.Session;
using TrailStore.Ordering.Application.Results;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Ordering.Application.Commands.ConfirmCheckout;

public sealed record ConfirmCheckoutCommand(ShoppingContextRef Ctx) : ICommand<OrderCreatedResult>;