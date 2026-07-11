using FastEndpoints;
using FluentValidation.Results;
using TrailStore.Ordering.Api.Extensions;

namespace TrailStore.Ordering.Api.PreProcessors;

public sealed class RequireCartId<TRequest> : IPreProcessor<TRequest>
{
    public Task PreProcessAsync(IPreProcessorContext<TRequest> ctx, CancellationToken ct)
    {
        var cartId = ctx.HttpContext.GetCartId();

        if (cartId is null)
        {
            return ctx.HttpContext.Response.SendErrorsAsync(
                [new ValidationFailure("cartId", "No active cart or checkout session was found.")],
                statusCode: 400,
                cancellation: ct);
        }
        
        return Task.CompletedTask;
    }
}