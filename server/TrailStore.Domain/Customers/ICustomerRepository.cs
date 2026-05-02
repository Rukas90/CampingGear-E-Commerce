using TrailStore.Domain.Models;

namespace TrailStore.Domain.Customers;

public interface ICustomerRepository
{
    Task<Customer> CreateAsync(Customer customer, CancellationToken ct);
    
    Task<Customer?> GetByEmailAsync(string email, CancellationToken ct);
    
    Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);
}