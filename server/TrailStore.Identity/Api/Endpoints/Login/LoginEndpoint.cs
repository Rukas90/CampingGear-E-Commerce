using FastEndpoints;
using TrailStore.Identity.Api.Api.Common;
using TrailStore.Identity.Api.Api.Cookies;
using TrailStore.Identity.Api.Api.Extensions;
using TrailStore.Identity.Api.Application.Commands.Login;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Identity.Api.Api.Endpoints.Login;

public class LoginEndpoint(LoginCommandHandler handler, IAuthCookieService authCookieService) 
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
        var result = await handler.Handle(new LoginCommand(req.Email, req.Password), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        authCookieService.AppendAuthCookies(
            HttpContext.Response, result.Value.Tokens);

        await Send.OkAsync(result.Value.Account.ToResponse(), ct);
    }
}