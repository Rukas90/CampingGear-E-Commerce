using FastEndpoints;
using TrailStore.Identity.Api.Common;
using TrailStore.Identity.Api.Cookies;
using TrailStore.Identity.Api.Extensions;
using TrailStore.Identity.Application.Commands.Login;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Identity.Api.Endpoints.Login;

public class LoginEndpoint(LoginCommandHandler command, IAuthCookieService authCookieService) 
    : Endpoint<LoginRequest, AccountResponse>
{
    public override void Configure()
    {
        Post("/api/v1/auth/login");
        AllowAnonymous();
        Throttle(4, 120);
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var result = await command.Handle(
            new LoginCommand(req.Email, req.Password, HttpContext.GetShoppingContext(User)), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        authCookieService.AppendAuthCookies(
            HttpContext.Response, result.Value.Tokens);

        HttpContext.ClearShoppingContext();
        
        await Send.OkAsync(result.Value.Account.ToResponse(), ct);
    }
}