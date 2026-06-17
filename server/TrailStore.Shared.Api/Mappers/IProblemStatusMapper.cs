namespace TrailStore.Shared.Api.Mappers;

public interface IProblemStatusMapper
{
    bool TryGetStatus(string code, out int status);
}