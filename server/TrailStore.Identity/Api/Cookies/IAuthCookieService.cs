using Microsoft.AspNetCore.Http;
using TrailStore.Identity.Application.Contracts;

namespace TrailStore.Identity.Api.Cookies;

public interface IAuthCookieService
{
    void AppendAuthCookies(HttpResponse response, TokenPair tokens);

    void RevokeAuthCookies(HttpResponse response);

    string SetCsrfToken(HttpResponse response);
}