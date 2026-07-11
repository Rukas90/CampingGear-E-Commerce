using Microsoft.Extensions.Logging;
using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Application.Abstractions;
using TrailStore.Identity.Application.Results;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Application.Commands.Register;

[AppService<RegisterCommandHandler>]
public class RegisterCommandHandler(
    IAuthService authService,
    IIdentityUnitOfWork unitOfWork,
    ICartService cartService,
    ILogger<RegisterCommandHandler> logger)
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

        var mergeResult = await cartService.MergeCart(command.guestCartId, newUser.Id.Value, ct);

        if (!mergeResult.IsSuccess)
        {
            logger.LogError("Failed to merge carts. Reason: {Reason}", mergeResult.Problem.Reason);
        }
        
        return new AuthResult(session, new UserAccountResult(newUser.Id, newUser.Email));
    }
}