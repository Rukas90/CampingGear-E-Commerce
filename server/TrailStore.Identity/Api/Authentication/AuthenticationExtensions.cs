using System.Text;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TrailStore.Identity.Api.Cookies;
using TrailStore.Shared.Domain.Problems;

namespace TrailStore.Identity.Api.Authentication;

public static class AuthenticationExtensions
{
    // ReSharper disable once UnusedMethodReturnValue.Global
    public static IServiceCollection AddAppAuthentication(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.MapInboundClaims = false;
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

                        var problem = SharedAuthProblems.Unauthenticated;

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
            })
            .AddCookie("External")
            .AddGoogle(options =>
            {
                options.ClientId = configuration["Google:ClientId"]!;
                options.ClientSecret = configuration["Google:ClientSecret"]!;
                options.SignInScheme = "External";
                options.UsePkce = true;
                options.CallbackPath = "/api/v1/auth/google/callback";
            });

        return services;
    }
}