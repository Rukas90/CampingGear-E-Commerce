using TrailStore.Identity.Application.Results;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Identity.Application.Commands.Refresh;

public sealed record RefreshCommand(string Token) : ICommand<AuthResult>;