using TrailStore.Shared.Common;

namespace TrailStore.Domain.ShoppingSessions.Errors;

public static class ShoppingSessionsProblems
{
    public static readonly Problem SessionNotFound
        = new("Not Found", "shopping.session.not_found", "Shopping session was not found.");
}