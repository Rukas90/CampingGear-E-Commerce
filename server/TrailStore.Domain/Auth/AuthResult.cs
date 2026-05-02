using TrailStore.Domain.Models;

namespace TrailStore.Domain.Auth;

public record AuthResult(Customer Customer, AuthTokens Tokens);