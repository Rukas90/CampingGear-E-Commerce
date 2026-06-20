using Microsoft.AspNetCore.Http;
using TrailStore.Identity.Api.Application.Contracts;

namespace TrailStore.Identity.Api.Api.Cookies;

public interface IAuthCookieService
{
    void AppendAuthCookies(HttpResponse response, TokenPair tokens);

    void RevokeAuthCookies(HttpResponse response);

    string SetCsrfToken(HttpResponse response);
}