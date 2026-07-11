using FastEndpoints;
using TrailStore.Identity.Api.Common;
using TrailStore.Identity.Api.Cookies;
using TrailStore.Identity.Api.Extensions;
using TrailStore.Identity.Application.Commands.Refresh;
using TrailStore.Shared.Api.Mappers;

namespace TrailStore.Identity.Api.Endpoints.Refresh;

public class RefreshEndpoint(RefreshCommandHandler command, IAuthCookieService authCookieService) 
    : EndpointWithoutRequest<AccountResponse>
{
    public override void Configure()
    {
        Post("/api/v1/auth/refresh");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var token = HttpContext.Request.ToRefreshToken();
        
        var result = await command.Handle(new RefreshCommand(token), ct);

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