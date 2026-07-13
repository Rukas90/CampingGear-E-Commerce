using TrailStore.Identity.Application.Results;

namespace TrailStore.Identity.Api.Cookies;

public interface IAuthCookieService
{
    void AppendAuthCookies(TokenPairResult tokens);

    void RevokeAuthCookies();
    
    void SetCsrfToken();
}