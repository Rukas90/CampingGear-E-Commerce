using Bogus;
using TrailStore.Catalog.Contracts.Skus;
using TrailStore.Catalog.Domain.Skus;
using TrailStore.Identity.Domain.Users;
using TrailStore.Ordering.Domain.Orders;
using TrailStore.Seed.Common;
using TrailStore.Shared.Domain.Common;

namespace TrailStore.Seed.Data;

// ReSharper disable All
public static class Orders
{
    [SeededEntity] public static readonly List<Order> All = CreateOrders();

    private static List<Order> CreateOrders()
    {
        var users = Users.All;

        var faker = new Faker<Order>();

        faker.UseSeed(94375185);

        faker.RuleFor(order => order.Id, f => Id<Order>.New());
        
        faker.RuleFor(
            o => Id<User>.From(o.UserId.HasValue ? o.UserId.Value : Guid.Empty), 
            f => f.PickRandom(users).Id);

        faker.RuleFor(order => order.EmailAddress, (f, o) =>
        {
            var email = users.FirstOrDefault(c => c.Id.Value == (o.UserId?.Value ?? Guid.Empty))?.Email;

            if (email is not null)
            {
                return email;
            }
            return f.PickRandom(users).Email;
        });
        
        faker.RuleFor(order => order.CreatedAt, f => f.Date.Past().ToUniversalTime());
        
        faker.RuleFor(order => order.Status, _ => OrderStatus.Completed);
        
        faker.RuleFor(order => order.BillingAddress, f => new BillingAddress()
        {
            RecipientFirstName = f.Name.FirstName(),
            RecipientLastName = f.Name.LastName(),
            AddressLine = f.Address.StreetAddress(),
            City = f.Address.City(),
            Region = f.Address.State(),
            PostalCode = f.Address.ZipCode(),
            CountryCode = "US",
            PhoneNumber = f.Phone.PhoneNumber()
        });
        
        var skus = SeedRunner.Discover<Sku>(SeedMarker.Reference).ToArray();

        faker.RuleFor(order => order.Items, (Faker f, Order order) =>
        {
            return f.Make(f.Random.Int(1, 5), i =>
            {
                var sku = f.PickRandom(skus);

                return new OrderItem
                {
                    Id = Id<OrderItem>.Part(order.Id).Part(i.ToString()).Build(),
                    OrderId = order.Id,
                    SkuId = Id<SkuRef>.From(sku.Id),
                    Quantity = f.Random.Int(1, 3),
                    UnitPrice = sku.UnitPrice,
                };
            });
        });
        
        faker.RuleFor(order => order.StatusUpdatedAt, (f, o) =>
            o.CreatedAt.AddMinutes(f.Random.Int(1, 60)));
        
        var usTaxRate = 1.08m;

        faker.RuleFor(order => order.TaxAmount, (f, o) 
            => o.Items.Sum(item => item.UnitPrice * item.Quantity) * usTaxRate);
        
        faker.RuleFor(order => order.TotalPrice, (f, o) =>
            o.Items.Sum(item => item.UnitPrice * item.Quantity) + o.TaxAmount);
        
        faker.RuleFor(order => order.Token, f => f.Random.AlphaNumeric(22));
            
        return faker.Generate(50);
    }
}