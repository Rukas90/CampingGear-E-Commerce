using TrailStore.Basket.Contracts.Carts;
using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Checkout;

public class CheckoutSession : AggregateRoot<CheckoutSession>, IEntityCreatable, IEntityUpdateable, IEntityExpirable
{
    public required Id<CartRef> CartId { get; init; }
    
    public CheckoutStatus Status { get; private set; }
    public Id<UserRef>? UserId { get; private set; }
    public string? EmailAddress { get; private set; }
    
    public ShippingAddress? ShippingAddress { get; private set; }
    public BillingAddress? BillingAddress { get; private set; }
    public bool ShippingAddressAsBillingAddress { get; private set; }
    
    public Id<ShippingMethod>? ShippingMethodId { get; private set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    
    public static CheckoutSession Create(Id<CartRef> cartId, TimeSpan expireTime)
        => new()
        {
            Id = Id<CheckoutSession>.New(),
            CartId = cartId,
            Status = CheckoutStatus.Draft,
            ExpiresAt = DateTime.UtcNow.Add(expireTime),
            ShippingAddressAsBillingAddress = true
        };

    public void Fill(SavedCheckoutDetails details)
    {
        EmailAddress = details.EmailAddress;
        ShippingAddress = details.ShippingAddress;
        BillingAddress = details.BillingAddress;
        ShippingAddressAsBillingAddress = details.ShippingAddressAsBillingAddress;
        ShippingMethodId = details.ShippingMethodId;
    }
    
    public Result AssignUser(Id<UserRef> userId, string emailAddress)
    {
        if (string.IsNullOrWhiteSpace(emailAddress))
        {
            return CheckoutProblems.EmailRequired;
        }

        UserId = userId;
        EmailAddress = emailAddress;
        
        return Result.Ok();
    }

    public Result UpdateEmailAddress(string? emailAddress)
    {
        if (UserId is not null && string.IsNullOrWhiteSpace(emailAddress))
        {
            return CheckoutProblems.EmailRequired;
        }
        
        EmailAddress = emailAddress;
        
        return Result.Ok();
    }

    public Result UpdateShippingAddress(ShippingAddress? address)
    {
        ShippingAddress = address;
        
        UpdateBillingAddress(BillingAddress);
        
        return Result.Ok();
    }
    
    public Result UpdateShippingMethodId(Id<ShippingMethod>? methodId)
    {
        ShippingMethodId = methodId;
        
        return Result.Ok();
    }

    public Result UpdateBilling(bool shippingAddressAsBillingAddress, BillingAddress? address)
    {
        ShippingAddressAsBillingAddress = shippingAddressAsBillingAddress;
        
        UpdateBillingAddress(address);
        
        return Result.Ok();
    }

    private void UpdateBillingAddress(BillingAddress? address)
    {
        BillingAddress = ShippingAddressAsBillingAddress 
            ? ShippingAddress is not null 
                ? new BillingAddress(ShippingAddress) : null
            : address;
    }
}