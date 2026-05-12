namespace TrailStore.Domain.Auth.Commands;

public record LoginCommand(
    string Email,
    string Password);