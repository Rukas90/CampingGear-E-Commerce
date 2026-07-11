using Microsoft.Extensions.Logging;
using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Application.Abstractions;
using TrailStore.Identity.Application.Results;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Application.Commands.Login;

[AppService<LoginCommandHandler>]
public sealed class LoginCommandHandler(
    IAuthService authService, 
    ICartService cartService,
    ILogger<LoginCommandHandler> logger) 
    : ICommandHandler<LoginCommand, AuthResult>
{
    public async Task<Result<AuthResult>> Handle(LoginCommand command, CancellationToken ct)
    {
        var result = await authService.LoginWithCredentials(command.Email, command.Password, ct);

        if (result.IsSuccess)
        {
            var mergeResult = await cartService.MergeCart(command.guestCartId, result.Value.Account.Id.Value, ct);
            
            if (!mergeResult.IsSuccess)
            {
                logger.LogError("Failed to merge carts. Reason: {Reason}", mergeResult.Problem.Reason);
            }
        }
        
        return result;
    }
}