using TrailStore.Identity.Api.Application.Abstractions;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Api.Application.Commands.Logout;

public sealed class LogoutCommandHandler(
    IRefreshService refreshService,
    IIdentityUnitOfWork unitOfWork) : ICommandHandler<LogoutCommand>
{
    public async Task<Result> Handle(LogoutCommand command, CancellationToken ct)
    {
        await refreshService.RevokeTokenFamily(command.RefreshToken, ct);
        
        await unitOfWork.SaveAsync(ct);
        
        return Result.Ok();
    }
}