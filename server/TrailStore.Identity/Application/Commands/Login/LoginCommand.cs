using TrailStore.Identity.Application.Results;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Identity.Application.Commands.Login;

public sealed record LoginCommand(string Email, string Password) : ICommand<AuthResult>;