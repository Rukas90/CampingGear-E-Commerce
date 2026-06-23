using TrailStore.Identity.Application.Contracts;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Identity.Application.Commands.Refresh;

public sealed record RefreshCommand(string Token) : ICommand<AuthResult>;