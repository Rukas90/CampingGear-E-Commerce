using FastEndpoints;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;

namespace TrailStore.Identity.Api.Endpoints.Google;

public sealed class GoogleLoginEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/api/v1/auth/google/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var props = new AuthenticationProperties
        {
            RedirectUri = "/api/v1/auth/google/complete"
        };
        
        await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, props);
        
        HttpContext.MarkResponseStart();
    }
}