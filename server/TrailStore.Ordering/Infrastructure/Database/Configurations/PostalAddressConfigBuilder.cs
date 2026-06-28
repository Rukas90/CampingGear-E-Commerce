using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrailStore.Ordering.Domain.Addresses;
using TrailStore.Ordering.Domain.Shipping;
using TrailStore.Shared.Domain.Abstractions;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Ordering.Infrastructure.Database.Configurations;

public static class PostalAddressConfigBuilder
{
    public static void ConfigureAddress<T, A>(OwnedNavigationBuilder<T, A> b) where T : class, IModel<T> where A : PostalAddress
    {
        Configure(b.Property(a => a.CountryCode), AddressConstraints.CountryCode);
        Configure(b.Property(a => a.RecipientFirstName), AddressConstraints.FirstName);
        Configure(b.Property(a => a.RecipientLastName), AddressConstraints.LastName);
        Configure(b.Property(a => a.Company), AddressConstraints.Company);
        Configure(b.Property(a => a.AddressLine), AddressConstraints.AddressLine);
        Configure(b.Property(a => a.ApartmentSuite), AddressConstraints.ApartmentSuite);
        Configure(b.Property(a => a.City), AddressConstraints.City);
        Configure(b.Property(a => a.Region), AddressConstraints.Region);
        Configure(b.Property(a => a.PostalCode), AddressConstraints.PostalCode);
        Configure(b.Property(a => a.PhoneNumber), AddressConstraints.PhoneNumber);
    }

    private static void Configure(PropertyBuilder property, FieldConstraint constraint)
    {
        property
            .HasMaxLength(constraint.MaxLength)
            .IsRequired(constraint.IsRequired);
    }
}