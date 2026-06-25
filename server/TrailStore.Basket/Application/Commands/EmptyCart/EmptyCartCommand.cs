using TrailStore.Basket.Domain.Sessions;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Application.Commands.EmptyCart;

public sealed record EmptyCartCommand(ShoppingContext ctx) : ICommand<Id<ShoppingSession>>;