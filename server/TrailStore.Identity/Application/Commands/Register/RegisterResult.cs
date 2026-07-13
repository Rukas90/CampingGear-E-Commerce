using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Application.Results;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Application.Commands.Register;

public sealed record RegisterResult(AuthResult Auth, Id<CartRef>? CartId);