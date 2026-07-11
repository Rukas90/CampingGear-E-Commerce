using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Application.Commands.InitiateCheckout;

public sealed record InitiateCheckoutCommand(Id<CartRef> CartId, Id<UserRef>? UserId) : ICommand;