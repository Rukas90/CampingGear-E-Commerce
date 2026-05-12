using System.Text;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TrailStore.Domain.Auth.Errors;
using TrailStore.Shared.Auth;

namespace TrailStore.Api.Auth.Extensions;

public static class AuthenticationExtensions
{
    // ReSharper disable once UnusedMethodReturnValue.Global
    public static IServiceCollection AddAppAuthentication(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!))
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies[AuthCookies.AccessToken];
                        return Task.CompletedTask;
                    },

                    OnChallenge = async context =>
                    {
                        context.HandleResponse();

                        var problem = AuthProblems.Unauthenticated;

                        await new ProblemDetails
                        {
                            Status = 401,
                            Errors =
                            [
                                new ProblemDetails.Error
                                {
                                    Name = problem.Title,
                                    Code = problem.Code,
                                    Reason = problem.Reason
                                }
                            ]
                        }.ExecuteAsync(context.HttpContext);
                    }
                };
            });

        return services;
    }
}