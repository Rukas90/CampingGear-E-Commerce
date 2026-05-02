using FastEndpoints;
using TrailStore.Api.Auth.Cookies;
using TrailStore.Api.Auth.Dto;
using TrailStore.Api.Auth.Mapping;
using TrailStore.Api.Common;
using TrailStore.Domain.Auth;

namespace TrailStore.Api.Auth.Endpoints;

public class RegisterEndpoint(IRegisterService registerService, IAuthCookieService authCookieService) 
    : Endpoint<RegisterRequest, AccountDto>
{
    public override void Configure()
    {
        Post("/api/v1/auth/register");
        AllowAnonymous();
        Throttle(3, 120);
    }

    public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
    {
        var result = await registerService.RegisterAsync(req.ToCommand(), ct);
        
        if (!result.IsSuccess)
        {
            await this.SendProblemAsync(result.Problem);
            return;
        }
        
        authCookieService.AppendAuthCookies(HttpContext.Response, result.Value.Tokens);
        await Send.OkAsync(result.Value.Customer.ToAccountDto(), ct);
    }
}