using TrailStore.Identity.Application.Abstractions;
using TrailStore.Identity.Application.Contracts;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Application.Commands.Register;

[AppService<RegisterCommandHandler>]
public class RegisterCommandHandler(
    IAuthService authService,
    IIdentityUnitOfWork unitOfWork)
    : ICommandHandler<RegisterCommand, AuthResult>
{
    public async Task<Result<AuthResult>> Handle(RegisterCommand command, CancellationToken ct)
    {
        var result = await authService.RegisterNewUser(command.Email, command.Password, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        var newUser = result.Value;
        var session = authService.CreateSession(newUser);
        
        await unitOfWork.SaveAsync(ct);

        return new AuthResult(session, new UserAccount(newUser.Id, newUser.Email));
    }
}