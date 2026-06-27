using System.Diagnostics.CodeAnalysis;
using TrailStore.Ordering.Domain.Shipping;

namespace TrailStore.Ordering.Domain.Orders;

public class BillingAddress : PostalAddress
{
    public BillingAddress() { }

    [SetsRequiredMembers]
    public BillingAddress(PostalAddress source) : base(source) { }
}