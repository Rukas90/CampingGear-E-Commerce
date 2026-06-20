using TrailStore.Identity.Api.Application.Contracts;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Identity.Api.Application.Commands.Register;

public sealed record RegisterCommand(string Email, string Password) : ICommand<AuthResult>;