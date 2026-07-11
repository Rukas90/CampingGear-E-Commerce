using TrailStore.Basket.Contracts.Session;
using TrailStore.Identity.Application.Results;
using TrailStore.Shared.Domain.Abstractions;

namespace TrailStore.Identity.Application.Commands.Login;

public sealed record LoginCommand(string Email, string Password, ShoppingContextRef Ctx) : ICommand<AuthResult>;