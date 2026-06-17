using TrailStore.Identity.Domain.Users;

namespace TrailStore.Identity.Application.Contracts;

public record AuthResult(TokenPair Tokens, UserAccount Account);