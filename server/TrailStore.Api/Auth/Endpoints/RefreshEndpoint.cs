using FastEndpoints;
using TrailStore.Api.Auth.Cookies;
using TrailStore.Api.Auth.Dto;
using TrailStore.Api.Auth.Mapping;
using TrailStore.Api.Common;
using TrailStore.Domain.Auth;
using TrailStore.Shared.Auth;

namespace TrailStore.Api.Auth.Endpoints;

public class RefreshEndpoint(IAuthService authService, IAuthCookieService authCookieService) : EndpointWithoutRequest<AccountDto>
{
    public override void Configure()
    {
        Post("/api/v1/auth/refresh");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var token = HttpContext.Request.Cookies[AuthCookies.RefreshToken];
        var result = await authService.RefreshSession(token, ct);

        if (!result.IsSuccess)
        {
            authCookieService.RevokeAuthCookies(HttpContext.Response);
            await this.SendProblemAsync(result.Problem);
            
            return;
        }
        
        authCookieService.AppendAuthCookies(HttpContext.Response, result.Value.Tokens);
        await Send.OkAsync(result.Value.Customer.ToAccountDto(), ct);
    }
}