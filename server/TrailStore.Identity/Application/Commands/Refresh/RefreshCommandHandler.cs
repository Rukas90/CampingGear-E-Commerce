using TrailStore.Identity.Api.Application.Abstractions;
using TrailStore.Identity.Api.Application.Contracts;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Api.Application.Commands.Refresh;

public sealed class RefreshCommandHandler(
    IAuthService authService, 
    IUnitOfWork unitOfWork) 
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