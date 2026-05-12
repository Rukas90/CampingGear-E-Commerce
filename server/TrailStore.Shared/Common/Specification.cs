using System.Linq.Expressions;
using LinqKit;

namespace TrailStore.Shared.Common;

public class Specification<T> : ISpecification<T>
{
    public static readonly Specification<T> Blank = new(_ => true);
    private readonly Expression<Func<T, bool>>? expression;

    private Specification(Expression<Func<T, bool>> expression)
    {
        this.expression = expression;
    }

    public Expression<Func<T, bool>> ToExpression()
    {
        return expression ?? (_ => true);
    }

    public Specification<T> And(Specification<T> other)
    {
        return new Specification<T>(ToExpression().And(other.ToExpression()));
    }

    public Specification<T> Or(Specification<T> other)
    {
        return new Specification<T>(ToExpression().Or(other.ToExpression()));
    }

    public Specification<T> Not()
    {
        return new Specification<T>(ToExpression().Not());
    }

    public static Specification<T> Where(Expression<Func<T, bool>> expression)
    {
        return new Specification<T>(expression);
    }
}