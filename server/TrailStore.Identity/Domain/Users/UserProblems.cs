using TrailStore.Shared.Domain.Common;

namespace TrailStore.Identity.Api.Domain.Users;

public static class UserProblems
{
    public static Problem ExistsByEmail(string email)
        => new("Email Taken", "user.email_taken", $"User by email {email} is already found.");
    
    public static Problem NotFound(string email)
        => new("Not Found", "user.not_found", $"User by email {email} is not found.");
}