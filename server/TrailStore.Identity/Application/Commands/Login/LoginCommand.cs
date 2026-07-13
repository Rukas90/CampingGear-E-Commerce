using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Application.Results;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Application.Commands.Login;

public sealed record LoginCommand(string Email, string Password, Id<CartRef>? guestCartId) : ICommand<LoginResult>;