using Bogus;
using TrailStore.Domain.Enums;
using TrailStore.Domain.Models;
using TrailStore.Domain.Orders;
using TrailStore.Shared.Common;

namespace TrailStore.Seed.Data;

// ReSharper disable All

public class Orders
{
    [SeededEntity]
    public static readonly List<Order> All = CreateOrders();

    private static List<Order> CreateOrders()
    {
        var customers = Customers.All;
        
        var faker = new Faker<Order>();
        
        faker.UseSeed(94375185);

        faker.RuleFor(order => order.Id, f => Id<Order>.Part(f.IndexFaker.ToString()).Build());

        faker.RuleFor(o => o.CustomerId, f => f.PickRandom(customers).Id);
        
        faker.RuleFor(order => order.CreatedAt, f => f.Date.Past().ToUniversalTime());
        
        faker.RuleFor(order => order.Status, _ => OrderStatus.Shipped);

        faker.RuleFor(o => o.EmailAddress, (f, o) => customers.First(c => c.Id == o.CustomerId).Email);
        
        faker.RuleFor(order => order.ShippingAddress, f => new PostalAddress
        {
            RecipientName = f.Name.FullName(),
            AddressLine1  = f.Address.StreetAddress(),
            City          = f.Address.City(),
            Region        = f.Address.State(),
            PostalCode    = f.Address.ZipCode(),
            CountryCode   = "US",
            PhoneNumber   = f.Phone.PhoneNumber()
        });
        
        faker.RuleFor(order => order.BillingAddress, f => new PostalAddress
        {
            RecipientName = f.Name.FullName(),
            AddressLine1  = f.Address.StreetAddress(),
            City          = f.Address.City(),
            Region        = f.Address.State(),
            PostalCode    = f.Address.ZipCode(),
            CountryCode   = "US",
            PhoneNumber   = f.Phone.PhoneNumber()
        });

        var skus = SeedRunner.Discover<Sku>(SeedRunner.Assembly).ToArray();
        
        faker.RuleFor(order => order.Items, (f, o) =>
        {
            return f.Make(f.Random.Int(1, 5), i =>
            {
                var sku = f.PickRandom(skus);
                
                return new OrderItem
                {
                    Id        = Id<OrderItem>.Part(o.Id).Part(i.ToString()).Build(),
                    OrderId   = o.Id,
                    SkuId     = sku.Id,
                    Quantity  = f.Random.Int(1, 3),
                    UnitPrice = sku.UnitPrice
                };
            });
        });
        
        return faker.Generate(50);
    }
}