using Microsoft.Extensions.Logging;
using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Application.Abstractions;
using TrailStore.Identity.Application.Results;
using TrailStore.Identity.Contracts.Users;
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
    : ICommandHandler<RegisterCommand, RegisterResult>
{
    public async Task<Result<RegisterResult>> Handle(RegisterCommand command, CancellationToken ct)
    {
        var result = await authService.RegisterNewUser(command.Email, command.Password, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }

        var newUser = result.Value;
        var session = authService.CreateSession(newUser);
        
        await unitOfWork.SaveAsync(ct);

        var authResult = new AuthResult(session, new UserAccountResult(newUser.Id, newUser.Email));
        
        var mergeResult = await cartService.MergeCart(command.guestCartId, Id<UserRef>.From(newUser.Id.Value), ct);

        if (!mergeResult.IsSuccess)
        {
            logger.LogError("Failed to merge carts. Reason: {Reason}", mergeResult.Problem.Reason);

            return new RegisterResult(authResult, CartId: null);
        }
        
        var cartId = mergeResult.Value;
        
        return new RegisterResult(authResult, cartId);
    }
}