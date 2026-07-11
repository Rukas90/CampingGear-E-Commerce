using TrailStore.Basket.Domain.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Basket.Application.Commands.EmptyCart;

public sealed record EmptyCartCommand(Id<Cart>? cartId, Id<UserRef>? userId) : ICommand<Id<Cart>>;