using TrailStore.Identity.Application.Contracts;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Identity.Application.Commands.Login;

public sealed record LoginCommand(string Email, string Password) : ICommand<AuthResult>;