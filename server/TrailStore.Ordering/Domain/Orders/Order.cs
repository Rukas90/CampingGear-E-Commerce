using TrailStore.Identity.Contracts.Users;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Orders;

public class Order : AggregateRoot<Order>, IEntityCreatable, IEntityUpdateable
{
    public required string Token { get; init; }
    public Id<UserRef>? UserId { get; init; }
    public required string EmailAddress { get; init; }
    public OrderStatus Status { get; private set; }
    public DateTime StatusUpdatedAt { get; private set; }
    public required decimal Subtotal { get; init; }
    public required decimal TaxAmount { get; init; }
    public required decimal TotalPrice { get; init; }
    public required BillingAddress BillingAddress { get; init; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    private List<OrderItem> _items = [];
    public IReadOnlyList<OrderItem> Items => _items;
    
    public OrderShipping Shipping { get; private set; } = null!;
    
    public static Order Create(OrderCreationInput input)
        => new()
        {
            Id = input.Id,
            Token = input.Token,
            UserId = input.UserId,
            Status = input.Status,
            StatusUpdatedAt = DateTime.UtcNow,
            EmailAddress = input.EmailAddress,
            BillingAddress = input.BillingAddress,
            Subtotal = input.Financials.Subtotal,
            TotalPrice = input.Financials.TotalPrice,
            TaxAmount = input.Financials.TaxAmount,
            Shipping = input.Shipping,
            _items = [..input.Items]
        };
    
    public Result MarkAsPaid()
    {
        if (Status == OrderStatus.OnHold)
        {
            return Result.Ok();
        }
        
        return SetStatus(OrderStatus.OnHold);
    }
    
    public Result MarkPaymentFailed()
    {
        if (Status == OrderStatus.OnHold)
        {
            return Result.Ok();
        }
        
        return SetStatus(OrderStatus.Failed);
    }
    
    public Result MarkAsCanceled()
    {
        if (Status is not OrderStatus.Pending)
        {
            return OrderProblems.CannotCancel(Status);
        }

        return SetStatus(OrderStatus.Canceled);
    }

    public Result MarkAsProcessing()
    {
        var result = SetStatus(OrderStatus.Processing);

        if (!result.IsSuccess)
        {
            return result;
        }
        
        return Result.Ok();
    }
    
    private Result SetStatus(OrderStatus newStatus)
    {
        if (IsTerminalStatus(Status))
        {
            return OrderProblems.OrderAlreadyFinalized(Status);
        }
        
        Status = newStatus;
        StatusUpdatedAt = DateTime.UtcNow;

        return Result.Ok();
    }

    private static bool IsTerminalStatus(OrderStatus status)
        => status
            is OrderStatus.Completed
            or OrderStatus.Canceled;
}