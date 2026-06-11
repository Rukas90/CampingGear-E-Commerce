using Microsoft.AspNetCore.Diagnostics;

namespace TrailStore.Api.Common.Middlewares;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext ctx, Exception ex, CancellationToken ct)
    {
        logger.LogError(ex, "Unhandled exception");
        
        ctx.Response.StatusCode = 500;
        
        await ctx.Response.WriteAsJsonAsync(new { error = "An unexpected error occurred." }, ct);
        
        return true;
    }
}