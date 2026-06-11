using TrailStore.Domain.Auth.Commands;
using TrailStore.Domain.Auth.Errors;
using TrailStore.Domain.Auth.Interfaces;
using TrailStore.Domain.Auth.Models;
using TrailStore.Domain.Customers.Interfaces;
using TrailStore.Domain.Shared.Interfaces;
using TrailStore.Domain.Shared.Models;
using TrailStore.Infrastructure.Shared;
using TrailStore.Shared.Common;

namespace TrailStore.Infrastructure.Auth;

[AppService<IRegisterService>]
public class RegisterService(
    ICustomerRepository customerRepository,
    IPasswordHasher passwordHasher,
    ILoginService loginService,
    IUnitOfWork unitOfWork) : IRegisterService
{
    public async Task<Result<AuthResult>> RegisterAsync(RegisterCommand command, CancellationToken ct)
    {
        if (await customerRepository.ExistsByEmailAsync(command.Email, ct))
        {
            return AuthProblems.EmailAlreadyTaken;
        }

        var customer = customerRepository.Add(
            Customer.Create(command.Email, passwordHasher.Hash(command.Password)));
        
        await unitOfWork.SaveAsync(ct);
        
        return new AuthResult(customer, await loginService.CreateAuthTokens(customer, ct));
    }
}