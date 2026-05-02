using TrailStore.Api.Auth.Dto;
using TrailStore.Domain.Auth.Commands;

namespace TrailStore.Api.Auth.Mapping;

public static class RequestMapping
{
    public static LoginCommand ToCommand(this LoginRequest req)
        => new(req.Email, req.Password);
    
    public static RegisterCommand ToCommand(this RegisterRequest req)
        => new(req.Email, req.Password);
}