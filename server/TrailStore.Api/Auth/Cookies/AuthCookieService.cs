using TrailStore.Api.Auth.Constants;
using TrailStore.Domain.Auth;
using TrailStore.Shared.Auth;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Auth.Cookies;

[AppService<IAuthCookieService>]
public class AuthCookieService(IWebHostEnvironment env, ICsrfService csrfService) : IAuthCookieService
{
    private CookieOptions AccessTokenOptions => new()
    {
        HttpOnly = true,
        Secure   = env.IsProduction(),
        SameSite = SameSiteMode.Lax,
        Expires  = DateTimeOffset.UtcNow.AddMinutes(15)
    };

    private CookieOptions RefreshTokenOptions => new()
    {
        HttpOnly = true,
        Secure   = env.IsProduction(),
        SameSite = SameSiteMode.Lax,
        Expires  = DateTimeOffset.UtcNow.AddDays(30),
        Path     = "/api/v1/auth/refresh"
    };
    
    private CookieOptions CsrfTokenOptions => new()
    {
        HttpOnly = false,
        Secure   = env.IsProduction(),
        SameSite = SameSiteMode.Lax,
        Path     = "/"
    };

    public void AppendAuthCookies(HttpResponse response, AuthTokens tokens)
    {
        response.Cookies.Append(
            AuthCookies.AccessToken, tokens.AccessToken, AccessTokenOptions);
        
        response.Cookies.Append(
            AuthCookies.RefreshToken, tokens.RefreshToken, RefreshTokenOptions);
    }

    public void RevokeAuthCookies(HttpResponse response)
    {
        response.Cookies.Delete(AuthCookies.AccessToken, AccessTokenOptions);
        response.Cookies.Delete(AuthCookies.RefreshToken, RefreshTokenOptions);
    }

    public string SetCsrfToken(HttpResponse response)
    {
        var token = csrfService.GenerateToken();
        
        response.Cookies.Append(CsrfConstants.CookieName, token, CsrfTokenOptions);
        
        return token;
    }
}