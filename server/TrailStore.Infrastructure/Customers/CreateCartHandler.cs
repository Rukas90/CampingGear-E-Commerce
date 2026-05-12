using MediatR;
using TrailStore.Domain.Carts.Interfaces;
using TrailStore.Domain.Customers.Events;
using TrailStore.Domain.Shared.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Customers;

public class CreateCartHandler(ICartRepository cartRepository)
    : INotificationHandler<CustomerRegisteredEvent>
{
    public async Task Handle(CustomerRegisteredEvent ev, CancellationToken ct)
    {
        await cartRepository.CreateAsync(new Cart
        {
            Id = Id<Cart>.New(),
            CustomerId = ev.Customer.Id
        });
    }
}