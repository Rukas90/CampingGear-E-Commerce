using System.Text.Json;
using FastEndpoints;
using Stripe;
using TrailStore.Domain.Carts.Models;
using TrailStore.Domain.Orders.Interfaces;

namespace TrailStore.Api.Checkout.Endpoints;

public class StripeWebhookEndpoint(
    IOrderService orderService,
    IConfiguration configuration) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/api/v1/webhooks/stripe");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync(ct);

        try
        {
            var stripeEvent = EventUtility.ConstructEvent(
                json,
                HttpContext.Request.Headers["Stripe-Signature"],
                secret: configuration["Stripe:WebhookSecret"]
            );

            if (stripeEvent.Type == EventTypes.PaymentIntentSucceeded)
            {
                var intent = (PaymentIntent)stripeEvent.Data.Object;
                var entries = JsonSerializer.Deserialize<CartLineItem[]>(intent.Metadata["cart"]);

                await orderService.ConfirmOrder(intent, entries!, ct);
            }

            await Send.OkAsync("Success.", ct);
        }
        catch (StripeException e)
        {
            await Send.ResultAsync(Results.BadRequest(e.Message));
        }
    }
}