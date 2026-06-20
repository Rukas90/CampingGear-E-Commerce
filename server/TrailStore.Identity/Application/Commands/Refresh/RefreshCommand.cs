using TrailStore.Identity.Api.Application.Contracts;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Identity.Api.Application.Commands.Refresh;

public sealed record RefreshCommand(string Token) : ICommand<AuthResult>;