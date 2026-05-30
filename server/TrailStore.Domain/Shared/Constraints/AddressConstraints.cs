using TrailStore.Shared.Common;

namespace TrailStore.Domain.Shared.Constraints;

public static class AddressConstraints
{
    public static readonly FieldConstraint CountryCode = new(MinLength: 2, MaxLength: 2, IsRequired: true);
    public static readonly FieldConstraint FirstName = new(MinLength: 1, MaxLength: 50, IsRequired: true);
    public static readonly FieldConstraint LastName = new(MinLength: 1, MaxLength: 50, IsRequired: true);
    public static readonly FieldConstraint Company = new(MinLength: 0, MaxLength: 100, IsRequired: false);
    public static readonly FieldConstraint AddressLine = new(MinLength: 1, MaxLength: 150, IsRequired: true);
    public static readonly FieldConstraint ApartmentSuite = new(MinLength: 0, MaxLength: 200, IsRequired: false);
    public static readonly FieldConstraint City = new(MinLength: 1, MaxLength: 100, IsRequired: true);
    public static readonly FieldConstraint Region = new(MinLength: 1, MaxLength: 100, IsRequired: false);
    public static readonly FieldConstraint PostalCode = new(MinLength: 1, MaxLength: 20, IsRequired: false);
    public static readonly FieldConstraint PhoneNumber = new(MinLength: 4, MaxLength: 40, IsRequired: true);
}