using System.Security.Cryptography;
using System.Text;
using FastEndpoints;
using TrailStore.Api.Auth.Constants;
using TrailStore.Domain.Auth;
using TrailStore.Shared.Common;

namespace TrailStore.Api.Auth.Middleware;

[AppService<CsrfValidateMiddleware>]
public class CsrfValidateMiddleware(ICsrfService csrfService) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!CsrfConstants.SafeMethods.Contains(context.Request.Method))
        {
            var cookieToken = context.Request.Cookies[CsrfConstants.CookieName];
            var headerToken = context.Request.Headers[CsrfConstants.HeaderName].FirstOrDefault();
            
            if (string.IsNullOrEmpty(cookieToken) 
                || string.IsNullOrEmpty(headerToken) 
                || cookieToken.Length != headerToken.Length 
                || !csrfService.VerifyToken(cookieToken) 
                || !csrfService.VerifyToken(headerToken) 
                || !CryptographicOperations.FixedTimeEquals(
                    Encoding.UTF8.GetBytes(cookieToken),
                    Encoding.UTF8.GetBytes(headerToken)))
            {
                await SendCsrfError(context);
                return;
            }
        }
        
        await next(context);
    }
    
    private static Task SendCsrfError(HttpContext context)
    {
        return new ProblemDetails
        {
            Status = 403,
            Errors =
            [
                new ProblemDetails.Error
                {
                    Name   = "Forbidden",
                    Code   = "csrf.invalid_token",
                    Reason = "Invalid or missing CSRF token."
                }
            ]
        }.ExecuteAsync(context);
    } 
}