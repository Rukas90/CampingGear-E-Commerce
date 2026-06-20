using TrailStore.Identity.Api.Application.Abstractions;
using TrailStore.Identity.Api.Application.Contracts;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Api.Application.Commands.Login;

public sealed class LoginCommandHandler(IAuthService authService) 
    : ICommandHandler<LoginCommand, AuthResult>
{
    public Task<Result<AuthResult>> Handle(LoginCommand command, CancellationToken ct)
    {
        return authService.LoginWithCredentials(command.Email, command.Password, ct);
    }
}