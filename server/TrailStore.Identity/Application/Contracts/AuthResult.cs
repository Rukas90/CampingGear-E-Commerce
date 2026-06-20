namespace TrailStore.Identity.Api.Application.Contracts;

public record AuthResult(TokenPair Tokens, UserAccount Account);