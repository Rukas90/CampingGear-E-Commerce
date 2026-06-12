using System.Diagnostics.CodeAnalysis;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Orders.Models;

public class BillingAddress : PostalAddress
{
    public BillingAddress() { }

    [SetsRequiredMembers]
    public BillingAddress(PostalAddress source) : base(source) { }
}