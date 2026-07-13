using TrailStore.Basket.Contracts.Carts;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Application.Results;

public record AuthResult(TokenPairResult Tokens, UserAccountResult Account);