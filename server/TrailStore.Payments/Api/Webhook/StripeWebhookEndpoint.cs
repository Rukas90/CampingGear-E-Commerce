using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Stripe;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Api.Mappers;
using TrailStore.Shared.Api.Metadata;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Payments.Api.Webhook;

public sealed class StripeWebhookEndpoint(
    IStripeWebhookProcessor stripeWebhookProcessor,
    IConfiguration configuration) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/api/v1/webhooks/stripe");
        AllowAnonymous();
        Options(b => b.WithMetadata(new IgnoreAntiforgery()));
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync(ct);

        try
        {
            var evt = EventUtility.ConstructEvent(json,
                HttpContext.Request.Headers["Stripe-Signature"],
                secret: configuration["Stripe:WebhookSecret"]);

            await stripeWebhookProcessor.ProcessEvent(evt, ct);
            await Send.OkAsync("Success.", ct);
        }
        catch (StripeException e)
        {
            await this.SendProblemAsync(new Problem("Webhook error", "stripe.webhook_error", e.Message));
        }
    }
}