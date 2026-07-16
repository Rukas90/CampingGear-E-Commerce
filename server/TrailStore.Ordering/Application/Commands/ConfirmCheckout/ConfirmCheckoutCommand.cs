using TrailStore.Basket.Contracts.Carts;
using TrailStore.Ordering.Application.Results;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Commands.ConfirmCheckout;

public sealed record ConfirmCheckoutCommand(bool SaveInformation, Id<CartRef> cartId) : ICommand<OrderCreatedResult>;