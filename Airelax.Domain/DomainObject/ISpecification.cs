using System;
using System.Linq.Expressions;

namespace Airelax.Domain.DomainObject
{
    public interface ISpecification<T>
    {
        bool IsSatisfy(T obj);
        ISpecification<T> And(ISpecification<T> specification);
        ISpecification<T> Or(ISpecification<T> specification);
        ISpecification<T> Not(ISpecification<T> specification);
    }
}