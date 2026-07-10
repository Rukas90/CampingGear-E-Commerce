using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stripe;
using TrailStore.Payments.Application.Abstractions;
using TrailStore.Payments.Domain;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Payments.Infrastructure.Payments;

[AppService<IStripeWebhookProcessor>]
public sealed class StripeWebhookProcessor(
    IPaymentRepository repository,
    ILogger<StripeWebhookProcessor> logger,
    IOptions<PaymentIntentOptions> options,
    IPaymentUnitOfWork unitOfWork) : IStripeWebhookProcessor
{
    private readonly string ReferenceKey = options.Value.ReferenceKey;
    
    public async Task ProcessEvent(Event evt, CancellationToken ct)
    {
        var eventId = evt.Id;
        var eventType = evt.Type;
        
        if (evt.Data.Object is not PaymentIntent intent)
        {
            logger.LogError("Event {EventId} was type {Type} but Data.Object was not a PaymentIntent.", 
                eventId, eventType);
         
            return;
        }
        
        if (!TryExtractReferenceKey(intent, out var referenceId))
        {
            logger.LogError(
                "Stripe event {EventId} for PaymentIntent {PaymentIntentId} missing/invalid order metadata key {OrderKey}. Metadata: {@Metadata}",
                eventId, intent.Id, ReferenceKey, intent.Metadata);
            
            return;
        }
        
        var payment = await repository.FindByReferenceId(referenceId, ct);

        if (payment is null)
        {
            logger.LogError("No payment by reference id {ReferenceId} was found", referenceId);
            
            return;
        }
        
        switch (eventType)
        {
            case EventTypes.PaymentIntentSucceeded:
                payment.ConfirmAttempt();
                break;
            
            case EventTypes.PaymentIntentPaymentFailed:
                payment.FailAttempt();
                break;
            
            case EventTypes.PaymentIntentCanceled:
                payment.CancelAttempt();
                break;
        }

        await unitOfWork.SaveAsync(ct);
        
        logger.LogInformation("Payment by reference id {ReferenceId} was processed with event {EventType}", referenceId, eventType);
    }

    private bool TryExtractReferenceKey(PaymentIntent intent, out Guid referenceId)
    {
        referenceId = Guid.Empty;
        
        if (intent.Metadata.TryGetValue(ReferenceKey, out var strValue) 
            && Guid.TryParse(strValue, out referenceId))
        {
            return true;
        }

        return false;
    }
}