using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Identity.Application.Commands.Logout;

public sealed record LogoutCommand(string Jti, string RefreshToken, DateTime SessionExpireAt) : ICommand;