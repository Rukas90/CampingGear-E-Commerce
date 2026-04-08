using System.Linq.Expressions;
using LinqKit;

namespace TrailStore.Shared.Common;

public class Specification<T> : ISpecification<T>
{
    private readonly Expression<Func<T, bool>>? expression;

    private Specification(Expression<Func<T, bool>> expression)
        => this.expression = expression;
    
    public Expression<Func<T, bool>> ToExpression()
        => expression ?? (_ => true);

    public static readonly Specification<T> Blank = new(_ => true);
    
    public Specification<T> And(Specification<T> other) 
        => new(expression: ToExpression().And(other.ToExpression()));
    
    public Specification<T> Or(Specification<T> other)  
        => new(expression: ToExpression().Or(other.ToExpression()));
    
    public Specification<T> Not()                       
        => new(expression: ToExpression().Not());
    
    public static Specification<T> Where(Expression<Func<T, bool>> expression)
        => new(expression);
}