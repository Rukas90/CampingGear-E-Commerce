namespace TrailStore.Shared.Api.Mappers;

public class ProblemStatusResolver(IEnumerable<IProblemStatusMapper> mappers)
{
    public int Resolve(string code)
    {
        foreach (var mapper in mappers)
        {
            if (mapper.TryGetStatus(code, out var status))
            {
                return status;
            }
        }
        return 400;
    }
}