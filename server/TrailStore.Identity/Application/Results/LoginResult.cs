using TrailStore.Basket.Contracts.Carts;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Application.Results;

public sealed record LoginResult(AuthResult Auth, Id<CartRef>? CartId);