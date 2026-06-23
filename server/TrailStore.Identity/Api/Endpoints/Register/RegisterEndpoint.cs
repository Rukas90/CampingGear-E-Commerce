using FastEndpoints;
using TrailStore.Identity.Api.Common;
using TrailStore.Identity.Api.Cookies;
using TrailStore.Identity.Api.Extensions;
using TrailStore.Identity.Application.Commands.Register;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Identity.Api.Endpoints.Register;

public class RegisterEndpoint(RegisterCommandHandler handler, IAuthCookieService authCookieService) 
    : Endpoint<RegisterRequest, AccountResponse>
{
    public override void Configure()
    {
        Post("/api/v1/auth/register");
        AllowAnonymous();
        Throttle(3, 120);
    }

    public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
    {
        var result = await handler.Handle(new RegisterCommand(req.Email, req.Password), ct);

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