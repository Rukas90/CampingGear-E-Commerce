using TrailStore.Domain.Auth.Commands;
using TrailStore.Domain.Auth.Errors;
using TrailStore.Domain.Auth.Interfaces;
using TrailStore.Domain.Auth.Models;
using TrailStore.Domain.Customers.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Shared;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Auth;

[AppService<IRegisterService>]
public class RegisterService(
    ICustomerRepository customerRepository,
    IPasswordHasher passwordHasher,
    ILoginService loginService) : IRegisterService
{
    public async Task<Result<AuthResult>> RegisterAsync(RegisterCommand command, CancellationToken ct)
    {
        if (await customerRepository.ExistsByEmailAsync(command.Email, ct)) return AuthProblems.EmailAlreadyTaken;

        var customer = await CreateCustomerAsync(command, ct);
        
        return new AuthResult(customer, await loginService.CreateAuthTokens(customer, ct));
    }

    private Task<Customer> CreateCustomerAsync(RegisterCommand command, CancellationToken ct)
    {
        return customerRepository.CreateAsync(new Customer
        {
            Id = Id<Customer>.New(),
            Email = command.Email,
            PasswordHash = passwordHasher.Hash(command.Password)
        }, ct);
    }
}