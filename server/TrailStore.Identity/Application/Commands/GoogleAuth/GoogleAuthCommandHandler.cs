
using Microsoft.Extensions.Logging;
using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Application.Abstractions;
using TrailStore.Identity.Application.Commands.Login;
using TrailStore.Identity.Application.Results;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Identity.Domain.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Application.Commands.GoogleAuth;

[AppService<GoogleAuthCommandHandler>]
public sealed class GoogleAuthCommandHandler(
    IUserRepository userRepository,
    IAuthService authService, 
    ICartService cartService,
    IIdentityUnitOfWork unitOfWork,
    ILogger<LoginCommandHandler> logger) : ICommandHandler<GoogleAuthCommand, LoginResult>
{
    public async Task<Result<LoginResult>> Handle(GoogleAuthCommand command, CancellationToken ct)
    {
        var user = await userRepository.FindByEmailAsync(command.Email, ct);

        if (user is null)
        {
            user = authService.RegisterNewUser(command.Email, password: null);
    
            await unitOfWork.SaveAsync(ct);
        }
        
        var session = authService.CreateSession(user);
        
        var authResult = new AuthResult(session, new UserAccountResult(user.Id, user.Email));
        
        var mergeResult = await cartService.MergeCart(
            command.GuestCartId, Id<UserRef>.From(user.Id.Value), ct);

        if (!mergeResult.IsSuccess)
        {
            logger.LogError("Failed to merge carts. Reason: {Reason}", mergeResult.Problem.Reason);

            return new LoginResult(authResult, CartId: null);
        }
        
        var cartId = mergeResult.Value;
        
        return new LoginResult(authResult, cartId);
    }
}