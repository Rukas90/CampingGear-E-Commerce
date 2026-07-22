using Microsoft.Extensions.Logging;
using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Application.Abstractions;
using TrailStore.Identity.Application.Results;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Identity.Domain.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Application.Commands.Register;

[AppService<RegisterCommandHandler>]
public class RegisterCommandHandler(
    IUserRepository userRepository,
    IAuthService authService,
    IIdentityUnitOfWork unitOfWork,
    ICartService cartService,
    ILogger<RegisterCommandHandler> logger)
    : ICommandHandler<RegisterCommand, LoginResult>
{
    public async Task<Result<LoginResult>> Handle(RegisterCommand command, CancellationToken ct)
    {
        var userExistsByEmail = await userRepository.ExistsByEmailAsync(command.Email, ct);

        if (userExistsByEmail)
        {
            return UserProblems.ExistsByEmail(command.Email);
        }
        
        var newUser = authService.RegisterNewUser(command.Email, command.Password);
        var session = authService.CreateSession(newUser);
        
        await unitOfWork.SaveAsync(ct);

        var authResult = new AuthResult(session, new UserAccountResult(newUser.Id, newUser.Email));
        
        var mergeResult = await cartService.MergeCart(command.GuestCartId, Id<UserRef>.From(newUser.Id.Value), ct);

        if (!mergeResult.IsSuccess)
        {
            logger.LogError("Failed to merge carts. Reason: {Reason}", mergeResult.Problem.Reason);

            return new LoginResult(authResult, CartId: null);
        }
        
        var cartId = mergeResult.Value;
        
        return new LoginResult(authResult, cartId);
    }
}