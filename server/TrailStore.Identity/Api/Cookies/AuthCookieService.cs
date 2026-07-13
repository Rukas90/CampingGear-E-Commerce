using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using TrailStore.Identity.Api.Csrf;
using TrailStore.Identity.Application.Results;
using TrailStore.Identity.Domain.Csrf;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Identity.Api.Cookies;

[AppService<IAuthCookieService>]
public class AuthCookieService(
    IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env, ICsrfService csrfService) 
    : IAuthCookieService
{
    private HttpContext Http => httpContextAccessor.HttpContext!;
    
    private CookieOptions AccessTokenOptions => new()
    {
        HttpOnly = true,
        Secure = env.IsProduction(),
        SameSite = SameSiteMode.Lax,
        Expires = DateTimeOffset.UtcNow.AddMinutes(15)
    };

    private CookieOptions RefreshTokenOptions => new()
    {
        HttpOnly = true,
        Secure = env.IsProduction(),
        SameSite = SameSiteMode.Lax,
        Expires = DateTimeOffset.UtcNow.AddDays(30),
        Path = "/api/v1/auth/refresh"
    };

    private CookieOptions CsrfTokenOptions => new()
    {
        HttpOnly = false,
        Secure = env.IsProduction(),
        SameSite = SameSiteMode.Lax,
        Path = "/"
    };

    public void AppendAuthCookies(TokenPairResult tokens)
    {
        Http.Response.Cookies.Append(
            AuthCookies.AccessToken, tokens.AccessToken, AccessTokenOptions);

        Http.Response.Cookies.Append(
            AuthCookies.RefreshToken, tokens.RefreshToken, RefreshTokenOptions);
    }

    public void RevokeAuthCookies()
    {
        Http.Response.Cookies.Delete(AuthCookies.AccessToken, AccessTokenOptions);
        Http.Response.Cookies.Delete(AuthCookies.RefreshToken, RefreshTokenOptions);
    }

    public void SetCsrfToken()
    {
        var token = csrfService.GenerateToken();

        Http.Response.Cookies.Append(CsrfConstants.CookieName, token, CsrfTokenOptions);
    }
}