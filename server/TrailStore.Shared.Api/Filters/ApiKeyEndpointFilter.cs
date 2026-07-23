using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TrailStore.Shared.Api.Filters;

public class ApiKeyEndpointFilter(string configurationKey) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        
        var expectedKey = config.GetValue<string>(configurationKey);
        
        var providedKey = context.HttpContext.Request.Headers["X-Api-Key"].FirstOrDefault();

        if (string.IsNullOrEmpty(expectedKey) || providedKey != expectedKey)
        {
            return Results.Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: "Unauthorized access",
                detail: "A valid API key was not provided in the X-Api-Key header."
            );
        }

        return await next(context);
    }
}