using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Application.Results;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Application.Commands.GoogleAuth;

public record GoogleAuthCommand(string Email, Id<CartRef>? GuestCartId) : ICommand<LoginResult>;