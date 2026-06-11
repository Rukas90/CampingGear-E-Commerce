using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Customers.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Customers;

[AppService<ICustomerRepository>]
public class CustomerRepository(AppDbContext context) : ICustomerRepository
{
    public Customer Add(Customer customer)
    {
        context.Customers.Add(customer);

        return customer;
    }

    public Task<Customer?> FindByEmailAsync(string email, CancellationToken ct)
    {
        return context.Customers
            .FirstOrDefaultAsync(customer => customer.Email == email, ct);
    }

    public Task<bool> ExistsByEmailAsync(string email, CancellationToken ct)
    {
        return context.Customers.AnyAsync(customer => customer.Email == email, ct);
    }
}