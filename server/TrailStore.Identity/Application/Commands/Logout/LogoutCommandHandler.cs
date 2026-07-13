using TrailStore.Identity.Application.Abstractions;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Application.Commands.Logout;

[AppService<LogoutCommandHandler>]
public sealed class LogoutCommandHandler(
    IRefreshService refreshService,
    IIdentityUnitOfWork unitOfWork) : ICommandHandler<LogoutCommand>
{
    public async Task<Result> Handle(LogoutCommand command, CancellationToken ct)
    {
        if (command.RefreshToken is not null)
        {
            await refreshService.RevokeTokenFamily(command.RefreshToken, ct);
        }
        
        await unitOfWork.SaveAsync(ct);
        
        return Result.Ok();
    }
}