using Microsoft.EntityFrameworkCore;
using TrailStore.Domain.Customers.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Data;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Customers;

[AppService<ICustomerRepository>]
public class CustomerRepository(AppDbContext context) : ICustomerRepository
{
    public async Task<Customer> CreateAsync(Customer customer, CancellationToken ct)
    {
        context.Customers.Add(customer);
        await context.SaveChangesAsync(ct);
        return customer;
    }

    public Task<Customer?> GetByEmailAsync(string email, CancellationToken ct)
    {
        return context.Customers
            .FirstOrDefaultAsync(customer => customer.Email == email, ct);
    }

    public Task<bool> ExistsByEmailAsync(string email, CancellationToken ct)
    {
        return context.Customers.AnyAsync(customer => customer.Email == email, ct);
    }
}