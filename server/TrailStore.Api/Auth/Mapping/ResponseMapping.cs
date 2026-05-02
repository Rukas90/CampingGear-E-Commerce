using TrailStore.Api.Auth.Dto;
using TrailStore.Domain.Models;

namespace TrailStore.Api.Auth.Mapping;

public static class ResponseMapping
{
    public static AccountDto ToAccountDto(this Customer customer)
        => new(customer.Id, customer.Email);
}