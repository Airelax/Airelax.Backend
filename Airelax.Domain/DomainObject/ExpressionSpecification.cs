using System;
using System.Linq.Expressions;

namespace Airelax.Domain.DomainObject
{
    public abstract class ExpressionSpecification<T> : Specification<T>
    {
        public override bool IsSatisfy(T obj)
        {
            return ToExpression().Compile()(obj);
        }

        public abstract Expression<Func<T, bool>> ToExpression();
        
        public static implicit operator Expression<Func<T, bool>>(ExpressionSpecification<T> specification)
        {
            return specification.ToExpression();
        }
    }
}