using System.Linq.Expressions;
using LinqKit;

namespace TrailStore.Shared.Common;

public class NotSpecification<T>(Specification<T> inner) : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression() => 
        inner.ToExpression().Not();
}