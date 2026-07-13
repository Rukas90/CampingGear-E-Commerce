using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Application.Results;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Application.Commands.Login;

public sealed record LoginResult(AuthResult Auth, Id<CartRef>? CartId);