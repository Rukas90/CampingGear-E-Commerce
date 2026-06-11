namespace TrailStore.Domain.Shared.Interfaces;

public interface IWorkScope : IAsyncDisposable
{
    Task CompleteAsync();
}