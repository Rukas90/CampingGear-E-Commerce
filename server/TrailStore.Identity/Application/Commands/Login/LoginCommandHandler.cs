using TrailStore.Identity.Application.Abstractions;
using TrailStore.Identity.Application.Results;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Application.Commands.Login;

[AppService<LoginCommandHandler>]
public sealed class LoginCommandHandler(IAuthService authService) 
    : ICommandHandler<LoginCommand, AuthResult>
{
    public Task<Result<AuthResult>> Handle(LoginCommand command, CancellationToken ct)
    {
        return authService.LoginWithCredentials(command.Email, command.Password, ct);
    }
}