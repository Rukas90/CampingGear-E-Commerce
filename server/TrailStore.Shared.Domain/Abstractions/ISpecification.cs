using System.Linq.Expressions;

namespace TrailStore.Shared.Domain.Abstractions;

public interface ISpecification<T>
{
    public Expression<Func<T, bool>> ToExpression();
}