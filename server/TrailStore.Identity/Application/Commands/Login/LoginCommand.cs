using TrailStore.Identity.Api.Application.Contracts;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Identity.Api.Application.Commands.Login;

public sealed record LoginCommand(string Email, string Password) : ICommand<AuthResult>;