using TrailStore.Basket.Contracts.Carts;
using TrailStore.Inventory.Contracts;
using TrailStore.Ordering.Application.Abstractions;
using TrailStore.Ordering.Application.Results;
using TrailStore.Ordering.Contracts.IntegrationEvents;
using TrailStore.Ordering.Domain.Checkout;
using TrailStore.Payments.Contracts.Payments;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Application.Commands.ConfirmCheckout;

[AppService<ConfirmCheckoutCommandHandler>]
public sealed class ConfirmCheckoutCommandHandler(
    ICheckoutSessionRepository checkoutSessionRepository,
    IOrderService orderService,
    IOrderingUnitOfWork unitOfWork,
    IOrderingOutbox outbox,
    IInventoryService inventoryService,
    IPaymentService paymentService)
    : ICommandHandler<ConfirmCheckoutCommand, OrderCreatedResult>
{
    public async Task<Result<OrderCreatedResult>> Handle(ConfirmCheckoutCommand command, CancellationToken ct)
    {
        var checkoutSession = await checkoutSessionRepository.FindByCartIdAsync(command.cartId, ct);
        
        if (checkoutSession is null) { return CheckoutProblems.NoSession; }
        
        var validation = CheckoutSessionValidator.Validate(checkoutSession);
        
        if (!validation.IsSuccess) { return validation.Problem; }

        var confirmation = checkoutSession.Confirm();

        if (!confirmation.IsSuccess) { return confirmation.Problem; }

        var validatedInformation = validation.Value;
        
        var request = await orderService.BuildOrderCreationInput(
            Id<CartRef>.From(command.cartId), validatedInformation, ct);

        if (!request.IsSuccess) { return request.Problem; }

        var order = orderService.CreateOrder(request.Value);
        
        var reservation = await inventoryService.ReserveStock(
            order.Items.Select(item => new StockReserveItem(item.SkuId, item.Quantity)).ToArray(), ct);

        if (!reservation.IsSuccess) { return reservation.Problem; }
        
        await paymentService.CreatePayment(
            new PaymentCreationInput(order.Id, order.TotalPrice, request.Value.CurrencyCode, MaxAttempts: 3), ct);

        outbox.Enqueue(new OrderCreatedIntegrationEvent(checkoutSession.CartId, checkoutSession.UserId));
        
        await unitOfWork.SaveAsync(ct);
        
        return Result.Success(new OrderCreatedResult(order.Id));
    }
}