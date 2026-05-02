using MediatR;
using TrailStore.Domain.Carts;
using TrailStore.Domain.Customers;
using TrailStore.Domain.Models;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Customers;

public class CreateCartHandler(ICartRepository cartRepository) 
    : INotificationHandler<CustomerRegisteredEvent>
{
    public async Task Handle(CustomerRegisteredEvent ev, CancellationToken ct)
    {
        await cartRepository.CreateAsync(new Cart
        {   
            Id         = Id<Cart>.New(),
            CustomerId = ev.Customer.Id
        });
    }
}