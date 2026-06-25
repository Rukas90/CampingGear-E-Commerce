using TrailStore.Identity.Application.Results;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Identity.Application.Commands.Register;

public sealed record RegisterCommand(string Email, string Password) : ICommand<AuthResult>;