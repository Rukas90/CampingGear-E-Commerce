namespace TrailStore.Ordering.Api.Common.PostalAddress;

public static class PostalAddressMapping
{
    public static Domain.Shipping.PostalAddress ToPostalAddress(this PostalAddressRequest request)
        => new()
        {
            CountryCode = request.CountryCode ?? "",
            RecipientFirstName = request.RecipientFirstName ?? "",
            RecipientLastName = request.RecipientLastName ?? "",
            Company = request.Company ?? "",
            AddressLine =  request.AddressLine ?? "",
            ApartmentSuite =  request.ApartmentSuite ?? "",
            City = request.City ?? "",
            Region = request.Region ?? "",
            PostalCode = request.PostalCode ?? "",
            PhoneNumber = request.PhoneNumber ?? ""
        };
    
    public static PostalAddressResponse ToResponse(this Domain.Shipping.PostalAddress address)
        => new()
        {
            CountryCode = address.CountryCode,
            RecipientFirstName = address.RecipientFirstName,
            RecipientLastName = address.RecipientLastName,
            Company = address.Company,
            AddressLine =  address.AddressLine,
            ApartmentSuite =  address.ApartmentSuite,
            City = address.City,
            Region = address.Region,
            PostalCode = address.PostalCode,
            PhoneNumber = address.PhoneNumber
        };
}