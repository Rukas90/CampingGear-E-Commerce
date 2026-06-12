using System.Diagnostics.CodeAnalysis;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Orders.Models;

public class ShippingAddress : PostalAddress
{
    public ShippingAddress() { }

    [SetsRequiredMembers]
    public ShippingAddress(PostalAddress source) : base(source) { }
}