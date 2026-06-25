namespace TrailStore.Identity.Application.Results;

public record AuthResult(TokenPairResult Tokens, UserAccountResult Account);