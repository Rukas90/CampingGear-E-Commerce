using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TrailStore.Shared.Api.Handlers;

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