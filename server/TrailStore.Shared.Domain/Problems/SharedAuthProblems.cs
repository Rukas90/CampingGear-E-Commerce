using TrailStore.Shared.Domain.Common;

namespace TrailStore.Shared.Domain.Problems;

public class SharedAuthProblems
{
    public static readonly Problem Unauthenticated =
        new("Unauthenticated", "auth.unauthenticated", "You are not authenticated.");
}