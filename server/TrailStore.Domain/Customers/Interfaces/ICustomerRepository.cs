using TrailStore.Domain.Shared.Models;

namespace TrailStore.Domain.Customers.Interfaces;

public interface ICustomerRepository
{
    Customer Add(Customer customer);

    Task<Customer?> FindByEmailAsync(string email, CancellationToken ct);

    Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);
}