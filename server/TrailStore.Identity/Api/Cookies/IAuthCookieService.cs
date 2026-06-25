using Microsoft.AspNetCore.Http;
using TrailStore.Identity.Application.Results;

namespace TrailStore.Identity.Api.Cookies;

public interface IAuthCookieService
{
    void AppendAuthCookies(HttpResponse response, TokenPairResult tokens);

    void RevokeAuthCookies(HttpResponse response);

    string SetCsrfToken(HttpResponse response);
}