using System.Security.Cryptography;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Shared.Domain.Common;
using TrailStore.Shared.Infrastructure.DI;

namespace TrailStore.Ordering.Infrastructure.Orders;

[AppService<IOrderService>]
public sealed class OrderService(
    IOrderRepository orderRepository) : IOrderService
{
    public Order CreateOrder(CreateOrderRequest request)
    {
        var orderId = Id<Order>.New();
        
        var orderShipping = OrderShipping.Create(
            orderId, 
            request.ShippingInfo.MethodId,
            request.ShippingInfo.Code, 
            request.ShippingInfo.Name, 
            request.ShippingInfo.Financials.CostBeforeTaxes,
            request.ShippingInfo.Financials.TaxAmount,
            request.ShippingInfo.Financials.CostAfterTaxes,
            request.ShippingInfo.Address);

        var items = request.Items
            .Select(item => OrderItem.Create(orderId, item))
            .ToArray();

        return orderRepository.Add(Order.Create(new OrderCreationInput
        {
            Id = orderId,
            Token = GenerateToken(OrderTokenConfig.RandomPartLength),
            UserId = request.UserId,
            Status = OrderStatus.Created,
            MaxPaymentAttempts = 1, // Current default
            EmailAddress = request.EmailAddress,
            BillingAddress = request.BillingAddress,
            Financials = request.Financials,
            Shipping = orderShipping,
            Items = items
        }));
    }
    
    private static string GenerateToken(int length)
    {
        // ReSharper disable once StringLiteralTypo
        const string Chars = "23456789ABCDEFGHJKMNPQRSTUVWXYZ";
        
        var bytes = RandomNumberGenerator.GetBytes(length);
        var chars = new char[length];
        
        for (var i = 0; i < length; i++)
        {
            chars[i] = Chars[bytes[i] % Chars.Length];
        }
        
        return $"{OrderTokenConfig.Prefix}{new string(chars)}";
    }
}