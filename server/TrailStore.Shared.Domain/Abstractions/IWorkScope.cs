namespace TrailStore.Shared.Domain.Abstractions;

public interface IWorkScope : IAsyncDisposable
{
    Task CompleteAsync();
}