using TrailStore.Identity.Application.Abstractions;
using TrailStore.Identity.Application.Results;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Application.Commands.Refresh;

[AppService<RefreshCommandHandler>]
public sealed class RefreshCommandHandler(
    IAuthService authService, 
    IIdentityUnitOfWork unitOfWork) 
    : ICommandHandler<RefreshCommand, AuthResult>
{
    public async Task<Result<AuthResult>> Handle(RefreshCommand command, CancellationToken ct)
    {
        var result = await authService.RefreshSession(command.Token, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        await unitOfWork.SaveAsync(ct);
        
        return result.Value;
    }
}