using FastEndpoints;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace TrailStore.Shared.Api.Handlers;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext ctx, Exception ex, CancellationToken ct)
    {
        if (ex is NpgsqlException or TimeoutException)
        {
            ctx.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
            
            await ctx.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Detail = "The database is temporarily unavailable. Please try again in a moment.",
                Status = StatusCodes.Status503ServiceUnavailable
            }, ct);
            
            return true;
        }
        
        logger.LogError(ex, "Unhandled exception");
        
        ctx.Response.StatusCode = StatusCodes.Status500InternalServerError;
            
        await ctx.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Detail = "An unexpected error occurred.",
            Status = StatusCodes.Status500InternalServerError
        }, ct);
        
        return true;
    }
}