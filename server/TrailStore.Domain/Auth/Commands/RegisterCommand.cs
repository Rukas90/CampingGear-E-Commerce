namespace TrailStore.Domain.Auth.Commands;

public record RegisterCommand(
    string Email,
    string Password
);