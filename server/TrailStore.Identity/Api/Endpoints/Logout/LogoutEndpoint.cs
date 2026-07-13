using FastEndpoints;
using Microsoft.Extensions.Logging;
using TrailStore.Identity.Api.Cookies;
using TrailStore.Identity.Application.Commands.Logout;
using TrailStore.Shared.Api.Extensions;

namespace TrailStore.Identity.Api.Endpoints.Logout;

public sealed class LogoutEndpoint(
    LogoutCommandHandler command, 
    IAuthCookieService authCookieService,
    ILogger<LogoutEndpoint> logger) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/api/v1/auth/logout");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var jti = HttpContext.Request.Cookies[AuthCookies.AccessToken];
        var refreshToken = HttpContext.Request.Cookies[AuthCookies.RefreshToken];
        
        var result = await command.Handle(new LogoutCommand(jti, refreshToken, User.GetExpiration()), ct);

        if (!result.IsSuccess)
        {
            logger.LogError("Something went wrong while logging out. Reason: {Reason}", result.Problem.Reason);
        }
        
        authCookieService.RevokeAuthCookies();
        
        await Send.OkAsync("Logout success", ct);
    }
}