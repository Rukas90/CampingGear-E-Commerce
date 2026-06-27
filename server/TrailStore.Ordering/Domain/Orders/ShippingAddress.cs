using System.Diagnostics.CodeAnalysis;
using TrailStore.Ordering.Domain.Shipping;

namespace TrailStore.Ordering.Domain.Orders;

public class ShippingAddress : PostalAddress
{
    public ShippingAddress() { }

    [SetsRequiredMembers]
    public ShippingAddress(PostalAddress source) : base(source) { }
}