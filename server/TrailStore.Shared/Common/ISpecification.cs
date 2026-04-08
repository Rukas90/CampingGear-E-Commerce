using System.Linq.Expressions;

namespace TrailStore.Shared.Common;

public interface ISpecification<T>
{
    public Expression<Func<T, bool>> ToExpression();
}