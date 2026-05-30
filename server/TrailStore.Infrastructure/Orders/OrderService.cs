using Microsoft.Extensions.Logging;
using Stripe;
using TrailStore.Domain.Carts.Models;
using TrailStore.Domain.Orders.Errors;
using TrailStore.Domain.Orders.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Orders;

[AppService<IOrderService>]
public class OrderService(
    IOrderRepository orderRepository,
    IOrderItemsService orderItemsService,
    RefundService refundService, 
    ILogger<IOrderService> logger) 
    : IOrderService
{
    public async Task<Result<Order>> ConfirmOrder(PaymentIntent intent, CartLineItem[] entries, CancellationToken ct)
    {
        Order order = null; //await orderRepository.GetByIntentIdAsync(intent.Id, ct);

        if (order is null)
        {
            logger.LogCritical(
                "Payment succeeded for intent {IntentId} but no matching order was found. Issuing refund.",
                intent.Id);

            await IssueRefund(intent, ct);
            
            return OrderProblems.IntentNotFound;
        }
        
        await orderItemsService.CreateOrderItems(order.Id, entries, ct);

        return order;

    }

    public async Task IssueRefund(PaymentIntent intent, CancellationToken ct)
    {
        try
        {
            await refundService.CreateAsync(new RefundCreateOptions
            {
                PaymentIntent = intent.Id,
                Reason = RefundReasons.Fraudulent
            }, cancellationToken: ct);

            logger.LogInformation("Automatic refund issued for intent {IntentId}", intent.Id);
        }
        catch (StripeException e)
        {
            logger.LogCritical(
                "Automatic refund FAILED for intent {IntentId}. Manual intervention required. Error: {Error}",
                intent.Id, e.Message);
        }
    }
}