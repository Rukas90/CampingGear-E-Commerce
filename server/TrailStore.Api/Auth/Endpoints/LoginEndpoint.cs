using FastEndpoints;
using TrailStore.Api.Auth.Cookies;
using TrailStore.Api.Auth.Dto;
using TrailStore.Api.Auth.Mapping;
using TrailStore.Api.Common;
using TrailStore.Api.Common.Extensions;
using TrailStore.Domain.Auth;

namespace TrailStore.Api.Auth.Endpoints;

public class LoginEndpoint(ILoginService loginService, IAuthCookieService authCookieService) 
    : Endpoint<LoginRequest, AccountDto>
{
    public override void Configure()
    {
        Post("/api/v1/auth/login");
        AllowAnonymous();
        Throttle(4, 120);
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var result = await loginService.Login(req.ToCommand(), ct);

        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            return;
        }
        
        authCookieService.AppendAuthCookies(HttpContext.Response, result.Value.Tokens);
        await Send.OkAsync(result.Value.Customer.ToAccountDto(), ct);
    }
}