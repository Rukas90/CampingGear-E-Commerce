using System.Security.Claims;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using TrailStore.Basket.Contracts.Session;
using TrailStore.Identity.Api.Cookies;
using TrailStore.Identity.Api.Extensions;
using TrailStore.Identity.Application.Commands.GoogleAuth;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Identity.Api.Endpoints.Google;

public sealed class GoogleAuthCompleteEndpoint(
    GoogleAuthCommandHandler command,
    IAuthCookieService authCookieService, 
    ICartCookieService cartCookieService,
    IConfiguration configuration) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/api/v1/auth/google/complete");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await HttpContext.AuthenticateAsync("External");

        if (!result.Succeeded)
        {
            await Send.ForbiddenAsync(ct);
            
            return;
        }

        var email = result.Principal!.FindFirst(ClaimTypes.Email)!.Value;

        var loginResult = await command.Handle(new GoogleAuthCommand(email, HttpContext.GetCartId()), ct);

        if (!loginResult.IsSuccess)
        {
            await this.SendProblemAsync(loginResult.Problem);
            
            return;
        }
        
        authCookieService.AppendAuthCookies(loginResult.Value.Auth.Tokens);
        cartCookieService.UpdateCart(loginResult.Value.CartId);

        await HttpContext.SignOutAsync("External");

        var redirectPath = $"{configuration.GetValue<string>("Client:Url")}";
        
        await Send.RedirectAsync(redirectPath, allowRemoteRedirects: true);
    }
}