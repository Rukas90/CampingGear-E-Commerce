using System.Linq.Expressions;
using LinqKit;

namespace TrailStore.Shared.Common;

public class AndSpecification<T>(Specification<T> left, Specification<T> right) : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression() => 
        left.ToExpression().And(right.ToExpression());
}