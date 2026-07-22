using Microsoft.Extensions.Logging;
using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Application.Abstractions;
using TrailStore.Identity.Application.Results;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Application.Commands.Login;

[AppService<LoginCommandHandler>]
public sealed class LoginCommandHandler(
    IAuthService authService, 
    ICartService cartService,
    IIdentityUnitOfWork unitOfWork,
    ILogger<LoginCommandHandler> logger)
    : ICommandHandler<LoginCommand, LoginResult>
{
    public async Task<Result<LoginResult>> Handle(LoginCommand command, CancellationToken ct)
    {
        var result = await authService.LoginWithCredentials(command.Email, command.Password, ct);

        if (!result.IsSuccess)
        {
            return result.Problem;
        }
        
        await unitOfWork.SaveAsync(ct);
        
        var authResult = result.Value;
        var account = authResult.Account;
            
        var mergeResult = await cartService.MergeCart(
            command.GuestCartId, Id<UserRef>.From(account.Id.Value), ct);
        
        if (!mergeResult.IsSuccess)
        {
            logger.LogError("Failed to merge carts. Reason: {Reason}", mergeResult.Problem.Reason);
            
            return new LoginResult(authResult, CartId: null);
        }
        
        var cartId = mergeResult.Value;
        
        return new LoginResult(authResult, cartId);
    }
}