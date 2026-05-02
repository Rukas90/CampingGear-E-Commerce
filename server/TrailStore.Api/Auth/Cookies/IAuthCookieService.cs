using TrailStore.Domain.Auth;

namespace TrailStore.Api.Auth.Cookies;

public interface IAuthCookieService
{
    void AppendAuthCookies(HttpResponse response, AuthTokens tokens);
    
    void RevokeAuthCookies(HttpResponse response);
    
    string SetCsrfToken(HttpResponse response);
}