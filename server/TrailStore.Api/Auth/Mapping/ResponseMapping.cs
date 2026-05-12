using TrailStore.Api.Auth.Dto;
using TrailStore.Domain.Shared.Models;

namespace TrailStore.Api.Auth.Mapping;

public static class ResponseMapping
{
    public static AccountDto ToAccountDto(this Customer customer)
    {
        return new AccountDto(customer.Id, customer.Email);
    }
}