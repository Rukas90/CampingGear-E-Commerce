using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Auth.Models;

public record AuthResult(Customer Customer, AuthTokens Tokens);