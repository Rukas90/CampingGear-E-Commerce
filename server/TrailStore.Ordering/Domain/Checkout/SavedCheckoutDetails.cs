using TrailStore.Identity.Contracts.Users;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Domain.Checkout;

public class SavedCheckoutDetails : AggregateRoot<SavedCheckoutDetails>, IEntityCreatable, IEntityUpdateable
{
    public required Id<UserRef> UserId { get; init; }
    
    public string EmailAddress { get; private set; }
    
    public ShippingAddress ShippingAddress { get; private set; }
    public Id<ShippingMethod> ShippingMethodId { get; private set; }
    
    public BillingAddress BillingAddress { get; private set; }
    public bool ShippingAddressAsBillingAddress { get; private set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public static SavedCheckoutDetails Create(Id<UserRef> userId, ValidatedCheckoutInformation information)
    {
        var savedCheckoutDetails = new SavedCheckoutDetails
        {
            Id = Id<SavedCheckoutDetails>.New(),
            UserId = userId
        };
        savedCheckoutDetails.Snapshot(information);

        return savedCheckoutDetails;
    }
    
    public void Snapshot(ValidatedCheckoutInformation information)
    {
        EmailAddress = information.EmailAddress;
        ShippingAddress = information.ShippingAddress;
        ShippingMethodId = information.ShippingMethodId;
        BillingAddress = information.BillingAddress;
        ShippingAddressAsBillingAddress = information.ShippingAddressAsBillingAddress;
    }
}