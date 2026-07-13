using TrailStore.Basket.Contracts.Carts;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Application.Commands.Register;

public sealed record RegisterCommand(string Email, string Password, Id<CartRef>? guestCartId) : ICommand<RegisterResult>;